using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WakeupMaterialBehaviour : MonoBehaviour
{
    public Material AwakeMaterial = null;
    public Material asleepMaterial = null;

    private Rigidbody _rigidBody = null;
    private MeshRenderer _renderer = null;

    private bool _wasAsleep = false;

    private void Awake()
    {
        //get components of of the object its attacted to
        _rigidBody = GetComponent<Rigidbody>();
        _renderer = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        //set material to asleep if rigidBody is asleep
        if (_wasAsleep && _rigidBody.IsSleeping() && asleepMaterial)
        {
            _wasAsleep = false;
            _renderer.material = asleepMaterial;
        }
        //set material to awake if rigidBody is awake
        else if (!_wasAsleep && !_rigidBody.IsSleeping() && AwakeMaterial)
        {
            _wasAsleep = true;
            _renderer.material = AwakeMaterial;
        }
    }

}
