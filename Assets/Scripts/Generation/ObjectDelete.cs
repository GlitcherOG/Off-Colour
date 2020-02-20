using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelete : MonoBehaviour
{
    public PlayerHandler player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
        Destroy(collision.gameObject);
        }
        else
        {
            player.curHealth -= 3;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
        Destroy(collision.gameObject);
        }
        else
        {
            player.curHealth -= 3;
        }
    }
}
