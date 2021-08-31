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

    private Vector4 m_motorVelocity;
    private void Awake()
    {
        m_frontLeftMotor = frontLeft.motor;
        m_frontRightMotor = frontRight.motor;
        m_backLeftMotor = backLeft.motor;
        m_backRightMotor = backRight.motor;

        m_motorVelocity = new Vector4(m_frontLeftMotor.targetVelocity, m_frontRightMotor.targetVelocity, m_backLeftMotor.targetVelocity, m_backRightMotor.targetVelocity);
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            m_frontLeftMotor.targetVelocity = m_motorVelocity.x;
            m_frontRightMotor.targetVelocity = m_motorVelocity.y;
            m_backLeftMotor.targetVelocity = m_motorVelocity.z;
            m_backRightMotor.targetVelocity = m_motorVelocity.w;

            m_frontLeftMotor.force = 100;
            m_frontRightMotor.force = 100;
            m_backLeftMotor.force = 100;
            m_backRightMotor.force = 100;
        }
        if(Input.GetAxis("Vertical") < 0)
        {
            m_frontLeftMotor.targetVelocity = -m_motorVelocity.x;
            m_frontRightMotor.targetVelocity = -m_motorVelocity.y;
            m_backLeftMotor.targetVelocity = -m_motorVelocity.z;
            m_backRightMotor.targetVelocity = -m_motorVelocity.w;

            m_frontLeftMotor.force = 100;
            m_frontRightMotor.force = 100;
            m_backLeftMotor.force = 100;
            m_backRightMotor.force = 100;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            m_frontLeftMotor.targetVelocity = m_motorVelocity.x;
            m_frontRightMotor.targetVelocity = -m_motorVelocity.y;
            m_backLeftMotor.targetVelocity = m_motorVelocity.z;
            m_backRightMotor.targetVelocity = -m_motorVelocity.w;

            m_frontLeftMotor.force = 100;
            m_frontRightMotor.force = 100;
            m_backLeftMotor.force = 100;
            m_backRightMotor.force = 100;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            m_frontLeftMotor.targetVelocity = -m_motorVelocity.x;
            m_frontRightMotor.targetVelocity = m_motorVelocity.y;
            m_backLeftMotor.targetVelocity = -m_motorVelocity.z;
            m_backRightMotor.targetVelocity = m_motorVelocity.w;

            m_frontLeftMotor.force = 100;
            m_frontRightMotor.force = 100;
            m_backLeftMotor.force = 100;
            m_backRightMotor.force = 100;
        }
        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            m_frontLeftMotor.force = 0;
            m_frontRightMotor.force = 0;
            m_backLeftMotor.force = 0;
            m_backRightMotor.force = 0;
        }

    }
}
