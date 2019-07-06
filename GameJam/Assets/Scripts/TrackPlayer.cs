using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{

    public GameObject player;

    private Vector3 targetPosition;

    private Vector3 currentVelocity = Vector3.zero;


    private void Update()
    {
        targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + 2f, -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, 0.001f);
    }

}
