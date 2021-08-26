using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    public float forceOnFire = 300;

    private bool fire = false;
    private bool canFire = true;

    private Rigidbody _rigidBody = null;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.isKinematic = true;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            _rigidBody.isKinematic = false;
            _rigidBody.AddForce(transform.forward * forceOnFire,ForceMode.VelocityChange);
            canFire = false;
        }
    }
}
