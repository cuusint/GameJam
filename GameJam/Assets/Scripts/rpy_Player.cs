using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpy_Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 5f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();  
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.velocity += new Vector2(0, 15f);
            rb.AddForce(Vector2.up*500);
        }


    }

}
