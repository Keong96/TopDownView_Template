using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    Quaternion camRotation;
    public float smoothSpeed = 0.125f;

    private void Start()
    {
        offset = transform.localPosition;
        camRotation = transform.localRotation;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        float x = Mathf.Round(smoothedPosition.x * 100.0f) * 0.01f;
        float y = Mathf.Round(smoothedPosition.y * 100.0f) * 0.01f;
        float z = Mathf.Round(smoothedPosition.z * 100.0f) * 0.01f;

        transform.position = new Vector3(x, y, z);
        
        transform.LookAt(target);
        transform.rotation = camRotation;
    }
}