using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabModule : MonoBehaviour
{
    public float y;
    public float cooldown = 1f;
    public float rotationZ;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, y);
        transform.Rotate(new Vector3(0, 0, rotationZ));
    }
}
