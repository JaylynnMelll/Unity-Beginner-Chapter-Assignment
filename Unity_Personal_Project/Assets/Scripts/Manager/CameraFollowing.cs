using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        if (target == null) return;
    }

    private void Update()
    {
        if (target == null) return;

        Vector3 cameraPosition = transform.position;
        cameraPosition.x = target.position.x;
        cameraPosition.y = target.position.y;
        transform.position = cameraPosition;

    }
}
