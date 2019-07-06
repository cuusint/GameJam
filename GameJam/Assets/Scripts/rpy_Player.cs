using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpy_Player : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public bool onGround = false;
    public float jumpHeight = 500f;
    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 3f;
    }
    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space)&&onGround)
        {
            rb.AddForce(Vector2.up * jumpHeight);
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
