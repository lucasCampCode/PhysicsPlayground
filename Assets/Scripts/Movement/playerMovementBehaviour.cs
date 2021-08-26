using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementBehaviour : MonoBehaviour
{
    private Rigidbody _rigidBody = null;

    [SerializeField]
    private float speed = 15;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // use wasd to apply a force in an objects direction
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 force = moveY * transform.forward + moveX * transform.right;

        _rigidBody.AddForce(force, ForceMode.VelocityChange);
    }
}
