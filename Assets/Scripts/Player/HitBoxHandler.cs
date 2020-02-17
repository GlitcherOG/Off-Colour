using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxHandler : MonoBehaviour
{
    
        public GameObject self;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player" && PlayerHandler.Instance.curHealth != 0 && PlayerHandler.Instance.Ghoster <= 0)
            {
                
            PlayerHandler.Instance.curHealth -= 1;
                Destroy(self.gameObject);
            }
        }
   
}
