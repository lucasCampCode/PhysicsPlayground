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
        //grabs original rotaion
        originalRotation = door.rotation;
    }
    public void ToggleDoor()
    {
        if (!_doorOpen)
        {//if door not open 
            //set it to its opened rotation
            door.rotation = Quaternion.Euler(rotateOnOpen.x, rotateOnOpen.y, rotateOnOpen.z);
            //toggle door
            _doorOpen = !_doorOpen;
        }
        else
        {
            //if door is opened 
            //set door rotaion to want it was at teh begining
            door.rotation = originalRotation;
            //toggle door
            _doorOpen = !_doorOpen;
        }
    }

}
