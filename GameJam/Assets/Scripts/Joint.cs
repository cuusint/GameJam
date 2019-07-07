using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Joint : MonoBehaviour {

    private DistanceJoint2D joint;
    private Rigidbody2D connectedBodyRb;
    public GameObject player;
    private EdgeCollider2D collider;
    private void Awake() {
        joint = GetComponent<DistanceJoint2D>();
        collider = GetComponent<EdgeCollider2D>();
        connectedBodyRb = joint.connectedBody?.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (joint.connectedBody) {
            PlayerManager.Instance.state.IsSwing = true;
            Vector2 offset = transform.position - player.transform.position;
            offset = offset.normalized;
            if (!(Vector2.Angle(offset, Vector2.up) > 45f)) {
                transform.up = offset;
                PlayerManager.Instance.state.SwingToLimit = false;
            } else {
                PlayerManager.Instance.state.SwingToLimit = true;
            }
        } else {
            connectedBodyRb = joint.connectedBody?.gameObject.GetComponent<Rigidbody2D>();
            transform.DORotateQuaternion(Quaternion.identity, 1f);
        }
    }

    public void BreakJoint() {
        if (joint.connectedBody) {
            joint.connectedBody = null;
            connectedBodyRb.velocity = new Vector2(connectedBodyRb.velocity.y * 1.5f, -connectedBodyRb.velocity.x * 1.5f);
            PlayerManager.Instance.state.IsSwing = PlayerManager.Instance.state.SwingToLimit = false;
            collider.enabled = true;
        }
    }

    public void GetPlayer() {
        if (!joint.connectedBody) {
            joint.connectedBody = player.GetComponent<Rigidbody2D>();
            player.transform.position = new Vector3(transform.position.x, transform.position.y - 3.5f, 0);
            collider.enabled = false;
        }
    }


}