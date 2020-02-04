using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.tag == "Spawnable")
        //{
        Destroy(collision.gameObject);
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag == "Spawnable")
        //{
        Destroy(collision.gameObject);
        //}
    }
}
