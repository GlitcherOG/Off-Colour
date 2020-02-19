using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float velX = 5f;
    public bool right;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (right == true)
        {
            rb.velocity = new Vector2(velX, 0);
        }
        else
        {
            rb.velocity = new Vector2(-velX, 0);
        }
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "Platform")
        {
            Destroy(this.gameObject);
        }
    }
}
