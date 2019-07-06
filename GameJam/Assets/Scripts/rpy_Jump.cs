using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpy_Jump : rpy_Player
{
    private float timer = 0f;
    private void Start()
    {
        base.Start();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y);
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            timer += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) && onGround)
        {
            if (timer > 2f)
                timer = 2f;
            rb.AddForce(Vector2.up * jumpHeight*(1f+timer/2));
            timer = 0f;
            
            onGround = false;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            onGround = true;

    }
}
