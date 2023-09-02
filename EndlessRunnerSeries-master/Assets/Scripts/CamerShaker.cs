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

        //Gera valor aleatorio para o eixo X e Y
        float cameraShakingOffSetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakingOffSetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;

        //Armazena os valores gerados acima
        Vector3 cameraIntermediatePosition = mainCamera.transform.position;

        cameraIntermediatePosition.x += cameraShakingOffSetX;
        cameraIntermediatePosition.y += cameraShakingOffSetY;
        mainCamera.transform.position = cameraIntermediatePosition;
    }

    void StopCameraShaking()
    {

        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;
    }
    
}
