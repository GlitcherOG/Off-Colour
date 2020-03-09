using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRemove : MonoBehaviour
{
    //On the trigger stay of a 2d object
    private void OnTriggerStay2D(Collider2D collision)
    {
        //If the gameobjects tag is platform
        if(collision.gameObject.tag == "Platform")
        {
            //Destroy the gameobject
            Destroy(collision.gameObject);
        }
    }
}
