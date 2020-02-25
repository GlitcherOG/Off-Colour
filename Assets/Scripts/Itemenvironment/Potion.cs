using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject self;

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player" && PlayerHandler.Instance.curMana != PlayerHandler.Instance.maxMana)
        {
            PlayerHandler.Instance.controller.Anim.SetTrigger("Magic");
            PlayerHandler.Instance.curMana += 1;
            Destroy(self.gameObject);
        }







    }
}
