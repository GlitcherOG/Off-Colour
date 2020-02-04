using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickManager : MonoBehaviour
{
    public Rigidbody2D rigid;
    public WallManager wall;
    public bool intact = true;
    

    // Start is called before the first frame update
    void Start()
    {
        

    }
    public void Collapse()
    {

        
        rigid.constraints = RigidbodyConstraints2D.None;
        intact = false;

    }
    void OnCollisionEnter2D(Collision2D other)
    {




        if (other.gameObject.tag == "Spike")
        {

            Collapse();

        }





    }
    // Update is called once per frame
    void Update()
    {
        
      
    }
}
