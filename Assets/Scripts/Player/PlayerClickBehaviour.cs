using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickBehaviour : MonoBehaviour
{
    public Camera cam;
    public GameObject cursorImage;

    private void Awake()
    {
        //lock the cursor at the begining of the game
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        //grad the ray from the camera mouse position
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            //when hit with a door handle
            if (hit.collider.CompareTag("DoorHandle"))
            {
                //activate temp Cursor
                cursorImage.SetActive(true);
                //whenever mouse is cliked toggle door
                if(Input.GetMouseButton(0))
                    hit.collider.gameObject.GetComponent<DoorBehaviour>().ToggleDoor();
            }
            else
            {
                //reset cursor if not used
                cursorImage.SetActive(false);
            }
        }
    }

}
