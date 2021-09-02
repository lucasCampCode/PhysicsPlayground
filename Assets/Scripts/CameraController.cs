using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float MaxDistance = 10.0f;
    public float sensitivity = 10;
    public bool invertY = false;
    public float relaxSpeed = 10.0f;
    private float _currentDistance;
    private void Update()
    {
        //Rotate the camera
        if (Input.GetMouseButton(1))
        {
            Vector3 angles = transform.eulerAngles;
            Vector2 rotation;
            rotation.x = Input.GetAxis("Mouse Y") * (invertY ? 1.0f : -1.0f);
            rotation.y = Input.GetAxis("Mouse X");
            //look up and down by rotating around X-axis
            angles.x += rotation.x * sensitivity;
            angles.x = Mathf.Clamp(angles.x, 0.0f, 75f);
            //look left and right by rotating arounf the y-axis
            angles.y += rotation.y * sensitivity;
            //set the angles
            transform.eulerAngles = angles;

        }
        //move the camera
        RaycastHit hit;
        if (Physics.Raycast(target.position, -transform.forward, out hit, MaxDistance))
            _currentDistance = hit.distance;
        else
            _currentDistance = Mathf.MoveTowards(_currentDistance, MaxDistance,relaxSpeed* Time.deltaTime);

        transform.position = target.position + (_currentDistance * -transform.forward);
    }
}
