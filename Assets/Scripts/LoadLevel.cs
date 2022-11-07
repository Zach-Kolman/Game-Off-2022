using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    private int _sceneToLoadIndex;
    public string linkID = "";
    public enum _sceneToLoad { test1, test2 }

    public _sceneToLoad loadedScene;
    Transform player;

    private bool inRangeToOpen = false;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        inRangeToOpen = true;
        player.GetComponent<DoorIDs>().doorID = linkID;
    }

    private void OnTriggerExit(Collider other)
    {
        inRangeToOpen = false;
    }

    private void Update()
    {
        if (!inRangeToOpen) return;

        if(player.GetComponent<PlayerMechanics>().inputAssets.use)
        {
            player.GetComponent<PlayerMechanics>().inputAssets.use = false;
            SetSceneToLoad();
        }
    }

    void SetSceneToLoad()
    {
        switch (loadedScene)
        {
            case _sceneToLoad.test1:
                _sceneToLoadIndex = 0;
                break;

            case _sceneToLoad.test2:
                _sceneToLoadIndex = 1;
                break;
        }

        SceneManager.LoadScene(_sceneToLoadIndex);
    }
}
