using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickManager : MonoBehaviour
{
    public Rigidbody2D rigid;
    
    public bool intact = true;
    public GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        self = this.gameObject;
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
    }
    public void Collapse()
    {
        self.tag = "Spike";
        rigid.constraints = RigidbodyConstraints2D.None;
        intact = false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Collapse();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
      
    }
}
