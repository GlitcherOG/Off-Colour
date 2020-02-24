using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public static PlayerHandler Instance = null;
    public CharacterController2D controller;
    public float speed = 40f;
    public float jump = 10f;
    public bool run;
    public GameObject Camera;
    public GameObject CameraLocation;
    public float maxHealth, curHealth, maxMana, curMana;
    public Slider healthBar, magicBar;
    public float Ghoster, Warper, Blaster, Stopper;
    public bool blasterAnimRunning;
    public bool CanCast;
    public Animator anim;
    public GameObject Ghost, Warp, Blast;
    // Start is called before the first frame update
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
    }
   
    // Update is called once per frame
    void Update()
    {
        if (CameraLocation.transform.position.x != 3-Stopper)
        {
            CameraLocation.transform.localPosition = new Vector3 (3-Stopper,0);
        }
        
        if (controller.Rigidbody.velocity.x <= 0.1 && run)
        {
            Stopper -= Time.deltaTime;
            if (Stopper <= 0)
            {
                curHealth -= 1;
                Stopper += 2;
                
            }
            else
            {
                
            }
        }
        if (controller.transform.position.y <= -2)
        {
            curHealth -= 1;
        }
        
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
        if (healthBar.value != curHealth / maxHealth)
        {
            healthBar.value = curHealth / maxHealth;
        }
        if (magicBar.value != curMana / maxMana)
        {
            magicBar.value = curMana / maxMana;
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
            anim.SetTrigger("Spell");
        }

        if (run)
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
        Camera.transform.position = new Vector3(CameraLocation.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
        float temp = gameObject.transform.position.x / 10;
        ScoreManager.distance = (float)Math.Round(temp);
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
