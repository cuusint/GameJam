using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerManager : MonoBehaviour {

    private Rigidbody2D rb;
    private BoxCollider2D collider;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() {
        //collider.enabled = rb.velocity.y > 0 ? false : true;
    }

}