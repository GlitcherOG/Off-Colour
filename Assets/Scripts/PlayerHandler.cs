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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(speed);
        if (Input.GetKeyDown("space"))
        {
            controller.Jump(jump);
        }
        Camera.transform.position = new Vector3(CameraLocation.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
        debug.text = transform.position.x.ToString();
    }
}
