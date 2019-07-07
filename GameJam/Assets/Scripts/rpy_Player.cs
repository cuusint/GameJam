using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpy_Player : MonoBehaviour {
    public float speed = 5f;
    public Rigidbody2D rb;
    private CapsuleCollider2D collider;
    public bool onGround = false;
    public float jumpHeight = 500f;
    private bool CanMoveHorizontally = false;
    public void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        rb.gravityScale = 3f;
    }
    public void FixedUpdate() {
        if (PlayerManager.Instance.state.IsSwing && PlayerManager.Instance.state.SwingToLimit) {
            CanMoveHorizontally = false;
        } else {
            CanMoveHorizontally = true;
        }
        if (CanMoveHorizontally) {
            float moveHorizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector3(moveHorizontal * speed, rb.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space) && onGround) {
                rb.AddForce(Vector2.up * jumpHeight);
                onGround = false;
                PlayerManager.Instance.state.OnGround = onGround;
            }
        } else {
            rb.velocity = Vector2.zero;
        }

    }



    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground")
            onGround = PlayerManager.Instance.state.OnGround = true;


    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "NPC")
            Debug.Log(0);
    }

}
