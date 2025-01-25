using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class SimpleCarController : MonoBehaviour
{
    [SerializeField] Transform bicycle;
    [SerializeField] Rigidbody rbBicycle;

    public Transform Bicycle => bicycle;
    public Rigidbody RbBicycle => rbBicycle;
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    public void FixedUpdate()
    {
        RbBicycle.centerOfMass = new Vector3(0, -1.5f, 0);
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float tiltAngle = steering * 0.01f;
        

        if (motor < 0.5f && motor > -0.5f)
        {
            bicycle.rotation = Quaternion.Euler(new Vector3(bicycle.rotation.x,bicycle.rotation.y,0));
        }
        else
        Bicycle.Rotate(new Vector3(0, 0, -tiltAngle));



        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.wheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.wheel.motorTorque = motor;
            }
        }
    }
    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider wheel;
        public bool motor; // is this wheel attached to motor?
        public bool steering; // does this wheel apply steer angle?
    }
}

