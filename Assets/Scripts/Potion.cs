﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameObject self;

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player" && PlayerHandler.curMana != PlayerHandler.maxMana)
        {
            PlayerHandler.curMana += 1;
            Destroy(self.gameObject);
        }







    }
}
