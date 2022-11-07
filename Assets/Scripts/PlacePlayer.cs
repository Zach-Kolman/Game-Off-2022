using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlayer : MonoBehaviour
{
    private static string transitionID;
    public string linkID;
    private Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transitionID = player.GetComponent<DoorIDs>().doorID;
    }
    // Start is called before the first frame update
    void Start()
    {

        if (transitionID == linkID)
        {
            player.position = transform.position;
            player.forward = transform.forward;
        }
        else
        {
            return;
        }
    }
}
