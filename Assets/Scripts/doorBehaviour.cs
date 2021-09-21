using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Transform door;
    public Vector3 rotateOnOpen;
    private bool _doorOpen = false;
    private Quaternion originalRotation;
    private void Awake()
    {
        originalRotation = door.rotation;
    }
    public void ToggleDoor()
    {
        if (!_doorOpen)
        {
            door.rotation = Quaternion.Euler(rotateOnOpen.x, rotateOnOpen.y, rotateOnOpen.z);
            _doorOpen = !_doorOpen;
        }
        else
        {
            door.rotation = originalRotation;
            _doorOpen = !_doorOpen;
        }
    }

}
