using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicViewAsset : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    public Canvas viewLayer;
    public float distanceDial;
    private BoxCollider boxBounds;
    private Vector3 closestBoxPos;

    void Start()
    {
        boxBounds = gameObject.AddComponent<BoxCollider>();
        closestBoxPos = boxBounds.ClosestPoint(cam.transform.position);
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, cam.transform.position) <
            (Vector3.Distance(closestBoxPos, cam.transform.position) + distanceDial))
        {
            viewLayer.planeDistance = 1001.0f;
        }
        else
        {
            viewLayer.planeDistance = 0.5f;
        }
    }
}
