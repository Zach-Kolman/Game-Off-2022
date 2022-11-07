using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetCameraPriority : MonoBehaviour
{
    private Transform player;
    public CinemachineVirtualCamera linkedCam;
    private CameraManagement CamManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        CamManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<CameraManagement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        CamManager.currentCam = linkedCam;

        CamManager.SwapCameras();
    }
}
