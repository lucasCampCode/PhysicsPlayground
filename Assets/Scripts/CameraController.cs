using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distanceFromTarget = 30.0f;
    public float sensitivity = 10;
    public bool invertY = false;
    private void Update()
    {
        //Rotate the camera
        if (Input.GetMouseButton(1))
        {
            Vector3 angles = transform.eulerAngles;
            Vector2 rotation;
            rotation.x = Input.GetAxis("Mouse Y") * (invertY ? -1.0f : 1.0f);
            rotation.y = Input.GetAxis("Mouse X");
            //look up and down by rotating around X-axis
            angles.x = Mathf.Clamp(angles.x + rotation.x * sensitivity,-90,90);
            //look left and right by rotating arounf the y-axis
            angles.y += rotation.y * sensitivity;
            //set the angles
            transform.eulerAngles = angles;

        }
        //move the camera
        transform.position = target.position + (distanceFromTarget * -transform.forward);
    }
}
