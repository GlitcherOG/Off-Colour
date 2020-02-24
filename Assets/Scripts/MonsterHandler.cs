using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHandler : MonoBehaviour
{
    
    //public Animation anim;
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        
        //if (anim.isPlaying == false)
        {
            self.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
