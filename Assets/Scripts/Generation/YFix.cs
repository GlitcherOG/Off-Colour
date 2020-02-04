using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YFix : MonoBehaviour
{
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, y);
        Destroy(this);
    }
}
