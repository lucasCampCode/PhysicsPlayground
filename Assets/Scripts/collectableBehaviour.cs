using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
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
        //grabs position time
        _posTime += Time.deltaTime * _posStep;
        //grab tilt time
        _angleTime += Time.deltaTime * _angleStep;
        //when 0 or 1 is reach flip the the step
        if (_posTime >= 1 || _posTime <= 0)
            _posStep *= -1;
        if (_angleTime >= 1 || _angleTime <= 0)
            _angleStep *= -1;
        //spin teh object
        _rotationEuler.y += angleRotateYSpeed;
        //make the object bob around
        _rotationEuler.z = Mathf.Lerp(-angleLerp,angleLerp,_angleTime);

        Quaternion rotation = Quaternion.Euler(_rotationEuler);
        //make the object look like its floating
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(_originalPosition,_offsetPosition, _posTime), transform.position.z);
        transform.rotation = rotation;
    }
}
