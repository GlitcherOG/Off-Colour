using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRemove : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            Destroy(collision.gameObject);
        }
    }
}
