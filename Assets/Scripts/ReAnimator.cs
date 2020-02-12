using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReAnimator : MonoBehaviour
{
    
    public GameObject self;

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            PlayerHandler.Ghoster += 10;
            Destroy(self.gameObject);
        }







    }



}
