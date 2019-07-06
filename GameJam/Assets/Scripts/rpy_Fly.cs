using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpy_Fly : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private float timer = 0f;
    private float restTime = 0.3f;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space)&&timer>restTime)
        {
            rb.AddForce(Vector2.up * 200);
            timer = 0f;
        }
    }
}
