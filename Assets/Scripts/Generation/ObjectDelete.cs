using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the tag of the player doesnt equal player
        if(collision.gameObject.tag != "Player")
        {
            //Destory the gameobject
            Destroy(collision.gameObject);
        }
        else
        {
            //Damage the player
            PlayerHandler.Instance.Damaged(3);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the tag of the player doesnt equal player
        if (collision.gameObject.tag != "Player")
        {
            //Destory the gameobject
            Destroy(collision.gameObject);
        }
        else
        {
            //Damage the player
            PlayerHandler.Instance.Damaged(3);
        }
    }
}
