using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Camera camera;
    public Transform target;
    public Rigidbody projectile;


    public float airTime = 2.0f;

    private Vector3 _displacement = new Vector3();
    private Vector3 _acceleration = new Vector3();
    private Vector3 _initialVelocity = new Vector3();
    private Vector3 _finalVelocity = new Vector3();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            LaunchProjectile(target.position);
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit))
            {
                LaunchProjectile(hit.transform.position);
            }
        }

    }
    public void LaunchProjectile(Vector3 Targetposition)
    {
        _displacement = Targetposition - transform.position;
        _acceleration = Physics.gravity;
        _initialVelocity = FindInitialVelocity(_displacement, _acceleration, airTime);
        _finalVelocity = FindFinalVelocity(_initialVelocity, _acceleration, airTime);

        Rigidbody instance = Instantiate(projectile, transform.position, transform.rotation);

        instance.AddForce(_initialVelocity, ForceMode.VelocityChange);
    }

    private Vector3 FindFinalVelocity(Vector3 initalVelocity,Vector3 acceleration, float time)
    {
        //v = v0 + at
        Vector3 finalVelocity = initalVelocity + acceleration * time;
        return finalVelocity;
    }
    private Vector3 FindDisplacement(Vector3 initalVelocity, Vector3 acceleration, float time)
    {
        //deltaX = v0t + 0.5f * a * t^2
        Vector3 displacement = initalVelocity * time + 0.5f * acceleration * time * time;
        return displacement;
    }
    private Vector3 FindInitialVelocity(Vector3 displacement,Vector3 acceleration,float time)
    {
        //deltaX = v0t + 0.5f * a * t^2
        //v0 = deltaX/t - 0.5f*a*t
        Vector3 initalVelocity = (displacement / time) - 0.5f * acceleration * time;

        return initalVelocity;
    }
}
