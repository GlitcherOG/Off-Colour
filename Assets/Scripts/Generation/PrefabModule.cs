using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabModule : MonoBehaviour
{
    public float y;
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, y);
    }
}
