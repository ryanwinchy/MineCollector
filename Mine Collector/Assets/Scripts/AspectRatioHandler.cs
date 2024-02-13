using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioHandler : MonoBehaviour
{


public float orthoSize16_9 = 5f;
public float orthoSize16_10 = 5.54f;
public float cameraYPos16_9 = 0f;
public float cameraYPos16_10 = 0.54f;

private Camera mainCamera;

void Start()
{
    mainCamera = Camera.main;

    // Call the method to set the aspect ratio initially
    SetCameraProperties();
}

void Update()
{
    // Call the method to set the aspect ratio during runtime (in case the window is resized)
    SetCameraProperties();
}

void SetCameraProperties()
{
    float currentAspect = (float)Screen.width / Screen.height;

    // Interpolate between 16:9 and 16:10 values based on the current aspect ratio
    float orthoSize = Mathf.Lerp(orthoSize16_9, orthoSize16_10, (currentAspect - 1f) / 0.1f);
    float cameraYPos = Mathf.Lerp(cameraYPos16_9, cameraYPos16_10, (currentAspect - 1f) / 0.1f);

    // Set the camera's orthographic size and position
    mainCamera.orthographicSize = orthoSize;
    mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, cameraYPos, mainCamera.transform.position.z);
}
}

