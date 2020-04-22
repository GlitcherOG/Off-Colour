using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public AudioSource danger, hurt; //Audio sources for sounds
    public static PlayerHandler Instance = null; //The main instance of the player Handler
    [Header("Base Stats")]
    public CharacterController2D controller; //The character controller for the player
    public float speed = 40f; //Speed of the player
    public float jump = 10f; //Jump height
    public bool run; // Bool if the player can run
    public float maxHealth, curHealth, maxMana, curMana; //Player Stats
    [Header("Camera Things")]
    public GameObject Camera; //The camera object
    public GameObject CameraLocation; //The location of where the y position of the camera should be
    public float Ghoster, Warper, Blaster, Stopper, Monster; //Check and Optimise
    float stopperCooldown; //Cooldown for how long the stopper goes
    [Header("Animation Things")]
    public bool blasterAnimRunning; //if the player is moving using the blaster
    public bool CanCast; //If the player can cast
    [Header("Objects")]
    public Slider healthBar; //Health bar of the player
    public Slider magicBar; //The amount of mana that the player has
    public GameObject Ghost, Warp, Blast, Roar; //The UI objects
    public Animator canvas; //The animator for the hurt animations 
    public GameObject self; //Self gameobject

    Vector2 prev; //Used for calculating the distance
    public Animator gobble; //Animation of the 
    float dis; //Distance between the moster and player

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        //Sets all the values to there default values
        Ghoster = 0;
        Warper = 0;
        Blaster = 0;
        maxHealth = 3;
        maxMana = 3;
        curHealth = maxHealth;
        curMana = 3;
        Stopper = 3;
        stopperCooldown = 2;
        Monster = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        dis = Vector2.Distance(prev, transform.position);
        prev = transform.position;
        Monster -= Time.deltaTime;
        if (Monster <= 0)
        {
            if (Roar.activeSelf == false)
            {
                danger.Play();
                Roar.transform.localPosition = new Vector2(-1.21f, transform.position.y - 14f);
            }
            Roar.SetActive(true);           
        }
        if (Monster <= -1)
        {
            Roar.SetActive(false);
            Monster += UnityEngine.Random.Range(20f, 40f);
        }
        
        if (dis <= 0.4 && run)
        {
            if (Stopper <= 0)
            {
                if (stopperCooldown <= 0 && GameManager.Instance.isDead == false)
                {
                    Damaged(1);
                    stopperCooldown = 2;
                }
                stopperCooldown -= Time.deltaTime;
            }
            else
            {
                Stopper -= Time.deltaTime;
            }
        }
        else if (run && Stopper <= 3 && dis >= 0.4)
        {
            Stopper += Time.deltaTime;
            stopperCooldown = 2;
        }
        if (controller.transform.position.y <= -2)
        {
            curHealth = 0;
        }
        if (curHealth == 0)
        {
            run = false;
            
            if (Stopper >= 0 && GameManager.Instance.isDead == false)
            {
                controller.Anim.SetTrigger("Death");
                GameManager.Instance.isDead = true;
            }
            else if (Stopper <= 0 && GameManager.Instance.isDead == false)
            {
                Roar.SetActive(true);
                controller.Anim.SetTrigger("Eaten");
                gobble.SetTrigger("Death");
                GameManager.Instance.isDead = true;
            }
        }
        if (curMana >= 1 || Blaster >= 0)
        {
            CanCast = true;
        }
        else
        {
            CanCast = false;
        }

        if (Input.GetKeyDown("e") && CanCast == true && !blasterAnimRunning)
        {
            blasterAnimRunning = true;
            if (Blaster <= 0)
            {
                curMana -= 1;
            }
            controller.Anim.SetTrigger("Spell");
        }
        CameraChecks();
        AblitiesCheck();
        if (run)
        {
            Movement();
        }
        UIElements(); //Update UI Elements
        float temp = gameObject.transform.position.x / 10; //Take the distance of the character from x zero and divide it by 10 
        ScoreManager.distance = (float)Math.Round(temp); //Round the value to a whole number and set into the score manager
    }

    void UIElements()
    {
        //Update the healthbar value if its not correct
        if (healthBar.value != curHealth / maxHealth)
        {
            healthBar.value = curHealth / maxHealth;
        }
        //Update the magic bar value if its not correct
        if (magicBar.value != curMana / maxMana)
        {
            magicBar.value = curMana / maxMana;
        }
    }

    void Movement()
    {
            controller.Move(speed);
            if (Input.GetKeyDown("space"))
            {
                controller.Jump(jump);
            }
            if (Input.GetKey("space") && controller.IsGrounded == false && controller.airTesting == true)
            {
                controller.glide = true;
            }
            else
            {
                controller.glide = false;
            }
    }

    void CameraChecks()
    {
        CameraLocation.transform.localPosition = new Vector3(3 - Stopper, 0);
        Camera.transform.position = new Vector3(CameraLocation.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
    }
    void AblitiesCheck()
    {
        if (Ghoster >= 0)
        {
            Ghoster -= Time.deltaTime;
            Ghost.SetActive(true);
            controller.Anim.SetBool("Ghost", true);
        }
        else
        {
            Ghost.SetActive(false);
            controller.Anim.SetBool("Ghost", false);
        }
        if (Warper >= 0)
        {
            Warper -= Time.deltaTime;
            Warp.SetActive(true);
        }
        else
        {
            Warp.SetActive(false);
        }
        if (Time.timeScale != 1f && Warper <= 0 && GameManager.Instance.isPaused == false)
        {
            Time.timeScale = 1f;
        }
        if (Blaster >= 0)
        {
            Blaster -= Time.deltaTime;
            Blast.SetActive(true);
        }
        else
        {
            Blast.SetActive(false);
        }
    }
    public void BlasterAnimRunning()
    {
        blasterAnimRunning = false;
    }
    public void StartRunning()
    {
        run = true;
    }

    public void Damaged(float damage)
    {
        curHealth -= damage;
        hurt.Play();
        canvas.SetTrigger("Hurt");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && Ghoster <= 0)
        {
            Damaged(1);
            Destroy(other);
        }
        if (other.tag == "Beer")
        {
            if (curHealth != maxHealth)
            {
                curHealth += 1;
            }
            controller.Anim.SetTrigger("Heal");
            Destroy(other.gameObject);
        }
        if (other.tag == "Potion")
        {
            if (curMana != maxMana)
            {
                curMana += 1;
            }
            controller.Anim.SetTrigger("Magic");
            Destroy(other.gameObject);
        }
        if (other.tag == "Ghoster")
        {
            Ghoster += 10;
            Destroy(other.gameObject);
        }
        if (other.tag == "Blast")
        {
            Blaster += 10;
            Destroy(other.gameObject);
        }
    }
}
