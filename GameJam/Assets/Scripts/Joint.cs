using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Joint : MonoBehaviour {

    private DistanceJoint2D joint;
    public GameObject player;
    private void Awake() {
        joint = GetComponent<DistanceJoint2D>();
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
            transform.DORotateQuaternion(Quaternion.identity, 1f);
        }
    }

    public void BreakJoint() {
        if (joint.connectedBody) {
            
            joint.connectedBody.velocity *= 3f;
            joint.connectedBody = null;
            PlayerManager.Instance.state.IsSwing = PlayerManager.Instance.state.SwingToLimit = false;
        }
    }

    public void GetPlayer() {
        if (!joint.connectedBody) {
            joint.connectedBody = player.GetComponent<Rigidbody2D>();
            player.transform.position = new Vector3(transform.position.x, transform.position.y - 2.5f, 0);
        }
    }


}