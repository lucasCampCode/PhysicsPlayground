using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickBehaviour : MonoBehaviour
{
    public Camera cam;
    public GameObject cursorImage;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            if (hit.collider.CompareTag("DoorHandle"))
            {
                cursorImage.SetActive(true);
                if(Input.GetMouseButton(0))
                    hit.collider.gameObject.GetComponent<DoorBehaviour>().ToggleDoor();
            }
            else
            {
                cursorImage.SetActive(false);
            }
        }
    }

}
