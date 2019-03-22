﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

    public Camera m_Camera;

    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);

        Vector3 eulerAngles = transform.eulerAngles;
        eulerAngles.z = 0;
        eulerAngles.x = 0;
        transform.eulerAngles = eulerAngles;
    }
}
