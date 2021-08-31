using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviiour : MonoBehaviour
{
    public float speed = 10;
    public float jumpStrength = 10.0f;
    public float gravityModifier = 1.0f;
    private CharacterController _controller;
    

    private Vector3 _desiredVelocity;
    private Vector3 _airVelocity;
    private bool _isJumpedDesired;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        //get jump input
        _isJumpedDesired = Input.GetButtonDown("Jump");

        //get movement input
        _desiredVelocity.x = Input.GetAxis("Horizontal");
        _desiredVelocity.y = 0.0f;
        _desiredVelocity.z = Input.GetAxis("Vertical");

        //set movement magnitude
        _desiredVelocity.Normalize();
        _desiredVelocity *= speed;

        //apply jump strength
        if (_isJumpedDesired)
        {
            _airVelocity.y = jumpStrength;
        }
        
        //apply gravity
        _airVelocity += Physics.gravity * gravityModifier * Time.deltaTime;
        _desiredVelocity += _airVelocity;

        //move
        _controller.Move(_desiredVelocity * Time.deltaTime);
    }
}
