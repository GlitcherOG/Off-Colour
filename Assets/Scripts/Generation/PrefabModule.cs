using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabModule : MonoBehaviour
{
    public float y; //The Y position of the Prefab to spawn at
    public float cooldown = 1f; //Cooldown of how long to wait before spawning another 
    public float rotationZ; //The z rotation of the object at spawn
    // Start is called before the first frame update
    void Start()
    {
        //transform the postion of the game object to the float y
        transform.position = new Vector3(transform.position.x, y);
        //rotate the gameobject to the rotationz
        transform.Rotate(new Vector3(0, 0, rotationZ));
    }
}
