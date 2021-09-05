using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleBehaviour : MonoBehaviour
{
    public HingeJoint frontLeft;
    public HingeJoint frontRight;
    public HingeJoint backLeft;
    public HingeJoint backRight;
    public float timer = 2;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CarHazard"))
        {
            Destroy(frontLeft,timer);
            Destroy(frontRight,timer);  
            Destroy(backLeft,timer);
            Destroy(backRight,timer);
        }
    }
}
