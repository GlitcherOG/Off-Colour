using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public static PlayerHandler Instance = null;
    [Header("Base Stats")]
    public CharacterController2D controller;
    public float speed = 40f;
    public float jump = 10f;
    public bool run;
    public float maxHealth, curHealth, maxMana, curMana; //Player Stats
    [Header("Camera Things")]
    public GameObject Camera;
    public GameObject CameraLocation;
    public float Ghoster, Warper, Blaster, Stopper; //Check and Optimise
    float stopperCooldown;
    [Header("Animation Things")]
    public bool blasterAnimRunning;
    public bool CanCast;
    [Header("Objects")]
    public Slider healthBar;
    public Slider magicBar; //Move off as well
    public GameObject Ghost, Warp, Blast; //Move off this
    // Start is called before the first frame update
    Vector2 prev;
    float dis;

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
        Ghoster = 0;
        Warper = 0;
        Blaster = 0;
        maxHealth = 3;
        maxMana = 3;
        curHealth = maxHealth;
        curMana = 3;
        Stopper = 3;
        stopperCooldown = 2;
    }

    // Update is called once per frame
    void Update()
    {
        dis = Vector2.Distance(prev, transform.position);
        prev = transform.position;
        if (dis <= 0.4 && run)
        {
            if (Stopper <= 0)
            {
                if (stopperCooldown <= 0)
                {
                    curHealth -= 1;
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
        }
        if (controller.transform.position.y <= -2)
        {
            curHealth = 0;
        }
        if (curHealth == 0)
        {
            GameManager.isDead = true;
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
        if(run)
        {
            Movement();
        }
        UIElements();
        float temp = gameObject.transform.position.x / 10;
        ScoreManager.distance = (float)Math.Round(temp);
    }

    void UIElements()
    {
        if (healthBar.value != curHealth / maxHealth)
        {
            healthBar.value = curHealth / maxHealth;
        }
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
        }
        else
        {
            Ghost.SetActive(false);
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
        if (Time.timeScale != 1f && Warper <= 0)
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
}
