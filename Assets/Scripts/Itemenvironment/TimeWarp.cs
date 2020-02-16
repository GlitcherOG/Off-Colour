using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarp : MonoBehaviour
{
    public GameObject self;

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            PlayerHandler.Instance.Warper += 10;
            Time.timeScale = 0.25f;
            Destroy(self.gameObject);
        }







    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
