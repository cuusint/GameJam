using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerManager : MonoBehaviour {

    public static PlayerManager Instance {
        get;
        private set;
    }

    private Rigidbody2D rb;
    private CapsuleCollider2D collider;
    public class State {
        public bool IsSwing {
            get; set;
        }

        public bool SwingToLimit {
            get; set;
        }

        public bool OnGround {
            get; set;
        }
    }

    public State state = new State();
    private void Awake() {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    private void Update() {
        //if (state.IsSwing) {
        //    HandleBreakJoint();
        //} else {
        //    HandleGraspJoint();
        //}

    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.tag == "Joint") {
            if (Input.GetKeyDown(KeyCode.G)) {
                collision.transform.GetComponent<Joint>().BreakJoint();
            }
            if (Input.GetKeyDown(KeyCode.F)) {
                collision.transform.GetComponent<Joint>().GetPlayer();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Joint") {
            if (Input.GetKeyDown(KeyCode.G)) {
                collision.transform.GetComponent<Joint>().BreakJoint();
            }
            if (Input.GetKeyDown(KeyCode.F)) {
                collision.transform.GetComponent<Joint>().GetPlayer();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Joint") {
            if (Input.GetKeyDown(KeyCode.G)) {
                collision.transform.GetComponent<Joint>().BreakJoint();
            }
            if (Input.GetKeyDown(KeyCode.F)) {
                collision.transform.GetComponent<Joint>().GetPlayer();
            }
        }
    }
    private void HandleBreakJoint() {


        collider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1.5f);
        collider.enabled = true;
        if (hit) {
            if (hit.transform.tag == "Joint") {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    hit.transform.GetComponent<Joint>().BreakJoint();
                }
            }
        }

    }

    private void HandleGraspJoint() {
        bool isGOingRight = rb.velocity.x > 0 ? true : false;
        Vector2 rayDirection = isGOingRight ? Vector2.right : Vector2.left;
        Vector2 rayOrigin = transform.position;
        float rayDistance = 0.5f;
        collider.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance);
        collider.enabled = true;
        if (hit) {
            if (hit.transform.tag == "Joint") {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    hit.transform.GetComponent<Joint>().GetPlayer();
                }
            }
        }

    }

}