using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpy_Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 5f;
    private Rigidbody2D rb;
    private bool onGround = false;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();  
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space)&&onGround)
        {
            rb.AddForce(Vector2.up*500);
            onGround = false;
        }
        


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            onGround = true;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
            Debug.Log(0);
    }

}
