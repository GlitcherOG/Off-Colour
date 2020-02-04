using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallManager : MonoBehaviour
{
    public float maxHealth, curHealth, repair, material;
    
    public GameObject self;
    public bool collapse = false;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
      

    }

    
    // Update is called once per frame
    void Update()
    {
        
        
        if(curHealth <= 0f)
        {

           
            collapse = true;
           
            

        }
        if(curHealth == maxHealth + 1)
        {
            
        }
        if(curHealth >= maxHealth)
        {
            collapse = false;
            

        }

    }
}
