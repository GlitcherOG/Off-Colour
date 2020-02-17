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
            PlayerHandler.Instance.Warper += 2;
            Time.timeScale = 0.4f;
            Destroy(self.gameObject);
        }







    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
