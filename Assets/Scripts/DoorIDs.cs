using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIDs : MonoBehaviour
{
    public string doorID = "";

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
