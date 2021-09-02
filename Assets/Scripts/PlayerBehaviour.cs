using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 10;
    public float jumpHeight = 10.0f;
    public float gravityModifier = 1.0f;
    public float airControl = 1.0f;

    public Camera PlayerCamera;

    private CharacterController _controller;
    private bool _grounded = false;
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
        //Physics.CheckSphere(groundCheck.position, 0.2f, layer);
        _grounded = _controller.isGrounded;

        //get movement input
        float inputRight = Input.GetAxis("Horizontal");
        _desiredVelocity.y = 0.0f;
        float inputForward = Input.GetAxis("Vertical");


        //get camera transforms
        Vector3 cameraForward = PlayerCamera.transform.forward;
        cameraForward.y = 0.0f;
        cameraForward.Normalize();
        Vector3 cameraRight = PlayerCamera.transform.right;
        _desiredVelocity = inputRight * cameraRight + inputForward * cameraForward;
        //set movement magnitude
        _desiredVelocity.Normalize();
        _desiredVelocity *= speed;

        //apply jump strength
        if (_isJumpedDesired && _grounded)
        {
            _airVelocity.y = Mathf.Sqrt((-2.0f * Physics.gravity.y) * jumpHeight);
        }
        else if (_grounded)
            _airVelocity.y = -1.0f;
        
        //apply gravity
        _airVelocity += Physics.gravity * gravityModifier * Time.fixedDeltaTime;
        _desiredVelocity += _airVelocity;

        //move
        _controller.Move(_desiredVelocity * Time.deltaTime);
    }
}
