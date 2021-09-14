using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectBehaviour : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Collectable"))
        {
            Destroy(hit.rigidbody.gameObject);
        }
    }
}
