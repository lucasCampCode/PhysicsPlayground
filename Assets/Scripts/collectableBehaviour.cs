using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableBehaviour : MonoBehaviour
{
    public float positionLerpOffset = 2;
    public float angleRotateYSpeed = 15;
    public float angleLerp = 30;
    [SerializeField, Range(0,1)]
    private float _posStep = 1;
    private float _posTime = 0.0f;
    [SerializeField, Range(0, 1)]
    private float _angleStep = 1;
    private float _angleTime = 0.0f;
    private float _originalPosition;
    private float _offsetPosition;
    private Vector3 _rotationEuler = new Vector3();
    private void Start()
    {
        _originalPosition = transform.position.y;
        _offsetPosition = transform.position.y + positionLerpOffset;
    }
    private void Update()
    {
        _posTime += Time.deltaTime * _posStep;
        _angleTime += Time.deltaTime * _angleStep;
        if (_posTime >= 1 || _posTime <= 0)
            _posStep *= -1;
        if (_angleTime >= 1 || _angleTime <= 0)
            _angleStep *= -1;

        _rotationEuler.y += angleRotateYSpeed;
        _rotationEuler.x = Mathf.Lerp(-angleLerp,angleLerp,_angleTime);

        Quaternion rotation = Quaternion.Euler(_rotationEuler);

        transform.position = new Vector3(transform.position.x, Mathf.Lerp(_originalPosition,_offsetPosition, _posTime), transform.position.z);
        transform.rotation = rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")){

            Destroy(gameObject);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
