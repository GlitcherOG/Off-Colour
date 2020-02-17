using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public GameObject self;

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            PlayerHandler.Instance.Blaster += 10;
            Destroy(self.gameObject);
        }







    }

}
