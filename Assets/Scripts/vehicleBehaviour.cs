using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicleBehaviour : MonoBehaviour
{
    public HingeJoint frontLeft;
    public HingeJoint frontRight;
    public HingeJoint backLeft;
    public HingeJoint backRight;

    private JointMotor m_frontLeftMotor;
    private JointMotor m_frontRightMotor;
    private JointMotor m_backLeftMotor;
    private JointMotor m_backRightMotor;

    private void Awake()
    {
        m_frontLeftMotor = frontLeft.motor;
        m_frontRightMotor = frontRight.motor;
        m_backLeftMotor = backLeft.motor;
        m_backRightMotor = backRight.motor;
    }

    private void FixedUpdate()
    {
        
    }
}
