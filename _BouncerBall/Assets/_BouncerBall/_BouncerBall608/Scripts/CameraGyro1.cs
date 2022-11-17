using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraGyro1 : MonoBehaviour
{
    Gyroscope m_Gyro;

    Vector3 m_originalEulerAngles;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
        m_originalEulerAngles = transform.eulerAngles;
    }

    private void Update()
    {
        //float gyroX = Input.gyro.attitude.eulerAngles.x;
        // transform.eulerAngles = m_originalEulerAngles + new Vector3(0, gyroX, 0);

        GyroModifier();
    }

    private static Quaternion GyroToUnity(Quaternion quaternion)
    {
        return new Quaternion(quaternion.x, quaternion.y, -quaternion.z, -quaternion.w);
    }

    private void GyroModifier()
    {
        transform.rotation = GyroToUnity(Input.gyro.attitude);
    }
}
