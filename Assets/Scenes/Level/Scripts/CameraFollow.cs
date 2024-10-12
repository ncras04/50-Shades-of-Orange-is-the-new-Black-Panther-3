using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform m_player;
    [SerializeField]
    private float smoothTime;
    private Vector3 currentVelocity;

    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, m_player.position, ref currentVelocity, smoothTime);
    }
}
