using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Singleton
    public static CameraController instance { get; private set; }

    public CinemachineVirtualCamera meteorCam;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void ZoomOut()
    {
        meteorCam.Priority = 20;
    }

    public void ZoomIn()
    {
        meteorCam.Priority = 9;
    }
}
