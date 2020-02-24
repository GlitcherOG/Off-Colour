using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickManager : MonoBehaviour
{


    public GameObject top;
    public Rigidbody2D rigid;

    public bool intact = true;
    public GameObject self;
    public PhysicsMaterial2D explode;
    // Start is called before the first frame update
    void Start()
    {
        self = this.gameObject;
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
    }
    public void Collapse()
    {
        Destroy(top);
        rigid.sharedMaterial = explode;
        self.tag = "Spike";
        rigid.sharedMaterial.friction = 0.1f;
        rigid.sharedMaterial.bounciness = 0.75f;
        rigid.constraints = RigidbodyConstraints2D.None;
        
        intact = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DangerZone" || collision.tag == "Spike")
        {
            Collapse();
        }
    }
    // Update is called once per frame
    void Update()
    {


    }
}

