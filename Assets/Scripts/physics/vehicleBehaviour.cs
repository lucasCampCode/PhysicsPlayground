using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleBehaviour : MonoBehaviour
{
    public HingeJoint frontLeft;
    public HingeJoint frontRight;
    public HingeJoint backLeft;
    public HingeJoint backRight;
    public float timer = 2;
    /// <summary>
    /// when car hits a object with the tag Hazard it loses its wheels
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Destroy(frontLeft,timer);
            Destroy(frontRight,timer);  
            Destroy(backLeft,timer);
            Destroy(backRight,timer);
        }
    }
}
