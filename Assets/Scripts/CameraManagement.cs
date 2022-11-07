using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CameraManagement : MonoBehaviour
{
    public CinemachineVirtualCamera[] cams;
    private int basePriority = 10;
    [HideInInspector]
    public CinemachineVirtualCamera currentCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SwapCameras()
    {
        foreach(CinemachineVirtualCamera cam in cams)
        {
            cam.Priority = basePriority;
        }

        currentCam.Priority = basePriority + 1;
    }
}
