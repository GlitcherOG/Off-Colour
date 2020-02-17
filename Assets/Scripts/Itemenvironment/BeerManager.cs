﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeerManager : MonoBehaviour
{
    public GameObject self;
    
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Player" && PlayerHandler.Instance.curHealth != PlayerHandler.Instance.maxHealth)
        {
            PlayerHandler.Instance.curHealth += 1;
            Destroy(self.gameObject);
        }
    }
}

