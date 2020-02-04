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
    public Text debug;
    public float maxHealth, curHealth;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 3;
        curHealth = maxHealth;
    }
    void OnCollisionEnter2D(Collision2D other)
    {




        if (other.gameObject.tag == "DangerZone")
        {
            curHealth -= 1;
            

        }





    }
    // Update is called once per frame
    void Update()
    {
        if (healthBar.value != curHealth/maxHealth)
        {
            healthBar.value = curHealth / maxHealth;
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
        Camera.transform.position = new Vector3(CameraLocation.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
        debug.text = transform.position.x.ToString();
    }
}
