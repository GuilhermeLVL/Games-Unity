using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerShaker : MonoBehaviour
{
    [Header("Camera Shaker Config")]
    Vector3 cameraInitialPosition;
    public float shakeMagnitude = 0.05f;
    public float shakeTime = 0.5f;
    public Camera mainCamera;

    
    public void ShakeIt()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking",0f,0.005f);
        Invoke("StopCameraShaking", shakeTime);

    }

    void StartCameraShaking()
    {

    }

    void StopCameraShaking()
    {

    }
    
}
