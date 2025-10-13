using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraController : MonoBehaviour {
    public float sensitivity = 2.0f;
    public float maxYAngle = 80.0f;
    private float rotationX = 0.0f;

    private void Update()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(Vector3.up * MouseX * sensitivity);

        rotationX -= MouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -maxYAngle, maxYAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);
    }
}
