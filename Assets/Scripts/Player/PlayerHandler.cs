using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed = 20f;
    public float jump = 10f;
    public GameObject Camera;
    public GameObject CameraLocation;
    public static float maxHealth, curHealth, maxMana, curMana;
    public Slider healthBar, magicBar;
    public static float Ghoster,Warper, Blaster;
    public static bool CanCast;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Ghoster = 0;
        Warper = 0;
        Blaster = 0;
        maxHealth = 3;
        maxMana = 3;
        curHealth = maxHealth;
        curMana = 0;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DangerZone") && Ghoster <= 0)
        {
            curHealth -= 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Ghoster >= 0)
        {
            Ghoster -= Time.deltaTime;
        }
        if (Warper >= 0)
        {
            Warper -= Time.deltaTime;
        }
        if (Time.timeScale == 0.25f && Warper <= 0)
        {
            Time.timeScale = 1f;
        }
        if (Blaster >= 0)
        {
            Blaster -= Time.deltaTime;
        }
       
        if (healthBar.value != curHealth/maxHealth)
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
        
        controller.Move(speed);
        if (Input.GetKeyDown("space"))
        {
            controller.Jump(jump);
            
        }
        if (curMana <= 0 || Blaster <= 0)
        {
            CanCast = false;
        }
        else
        {
            CanCast = true;
        }
        
        if (Input.GetKeyDown("e") && CanCast == true)
        {
            controller.Magic();
            anim.SetTrigger("Spell");

        }
        Camera.transform.position = new Vector3(CameraLocation.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
        float temp = gameObject.transform.position.x/10;
        ScoreManager.distance = (float)Math.Round(temp);
    }
}
