using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed = 20f;
    public float jump = 10f;
    public GameObject Camera;
    public GameObject CameraLocation;
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
    }
}
