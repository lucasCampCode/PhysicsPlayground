using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementBehaviour : MonoBehaviour
{
    public List<Rigidbody> limbs;
    public float speed = 10;
    public float sprintSpeed = 20;
    public float stamina = 10;
    public float jumpHeight = 10.0f;
    public float gravityModifier = 1.0f;
    public float airControl = 1.0f;
    public bool faceWithCamera = false;
    public LayerMask layer;
    public Transform groundCheck;
    public Camera PlayerCamera;
    [SerializeField]
    private Animator _animator;

    private Rigidbody _body;
    private bool _grounded = false;
    private Vector3 _desiredVelocity;
    private Vector3 _airVelocity;
    private bool _isJumpedDesired;
    private bool _dead = false;
    private bool _isSprinting = false;
    private float _curStamina = 10;
    private bool _sprintDepleted = false;

    public bool Dead { set { _dead = value; } }

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
        foreach(Rigidbody body in limbs)
        {
            body.detectCollisions = false;
            body.isKinematic = true;
            if (body.gameObject.GetComponent<Collider>())
            {
                body.gameObject.GetComponent<Collider>().enabled = false;
            }
        }
    }
    private void Update()
    {
        //get jump input
        _isJumpedDesired = Input.GetButtonDown("Jump");
        //Physics.CheckSphere(groundCheck.position, 0.2f, layer);
        _grounded = Physics.CheckSphere(groundCheck.position, 0.2f, layer);
        _isSprinting = Input.GetKey(KeyCode.LeftShift);
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
        _desiredVelocity.Normalize();

        if (_isSprinting && _curStamina > 0 && !_sprintDepleted)
        {
            _curStamina -= Time.deltaTime * 2;
            _desiredVelocity *= sprintSpeed;
        }
        else
        {
            if (_curStamina < 0)
            {
                _sprintDepleted = true;
                _curStamina = 0;
            }
            if (_sprintDepleted || _curStamina <= stamina)
            {
                _curStamina += Time.deltaTime;
                if (_curStamina >= stamina)
                    _curStamina = stamina;
                else if (_curStamina >= stamina / 2)
                    _sprintDepleted = false;
            }
            //set movement magnitude
            _desiredVelocity *= speed;
        }

         _animator.SetFloat("Speed", _desiredVelocity.magnitude / speed);
        //change player facing
        if (faceWithCamera && !_dead)
        {
            transform.forward = cameraForward;
            _animator.SetFloat("Speed", inputForward);
            _animator.SetFloat("Direction", inputRight);
        }
        else if (_desiredVelocity != Vector3.zero && !_dead)
        {
            transform.forward = _desiredVelocity;
        }

        _animator.SetBool("Jump",!_grounded);
        //apply jump strength
        if (_isJumpedDesired && _grounded)
        {
            _airVelocity.y = Mathf.Sqrt(-2.0f * Physics.gravity.y * jumpHeight);
        }
        else if (_grounded)
            _airVelocity.y = 0;

        _airVelocity.y += Physics.gravity.y * Time.deltaTime;
        _animator.SetFloat("VerticalSpeed", _airVelocity.y / jumpHeight);
        Debug.Log(_desiredVelocity);
        //move
        if(!_dead)
            _body.velocity = _desiredVelocity + _airVelocity;
        else
            foreach (Rigidbody body in limbs)
            {
                body.detectCollisions = true;
                body.isKinematic = false;
                if (body.gameObject.GetComponent<Collider>())
                {
                    body.gameObject.GetComponent<Collider>().enabled = true;
                }
            }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            _dead = true;
            _animator.enabled = false;
        }
    }
}
