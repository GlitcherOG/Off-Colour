using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickManager : MonoBehaviour
{
    public Rigidbody2D rigid;
    public WallManager wall;
    public bool intact = true;
    Vector2 oldPos;
    public Quaternion originalRotationValue;

    // Start is called before the first frame update
    void Start()
    {
        oldPos = transform.position;
        originalRotationValue = gameObject.transform.rotation;

    }
    public void Collapse()
    {

        transform.Translate(0, 1);
        rigid.constraints = RigidBody2Dconstraints.none;
        intact = false;

    }
    private void OnTriggerEnter(Collider other)
    {




        if (other.tag == "Spike")
        {

            Collapse();

        }





    }
    // Update is called once per frame
    void Update()
    {
        
        if (wall.collapse == false && intact == false)
        {
            intact = true;
            transform.rotation = originalRotationValue;
            transform.position = oldPos;
            rigid.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ;

        }
    }
}
