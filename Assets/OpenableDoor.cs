using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OpenableDoor : MonoBehaviour
{
    public GameObject player;
    public SimplePickup neededItem;

    private TextMeshProUGUI text;

    private bool hasOpened = false;

    public GameObject logCanvas;

    public Transform door1;

    public Transform door2;

    public bool isLevelChange = false;

    private void Start()
    {
        text = logCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>();

        text.text = neededItem.nameText.ToString() + " required";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (hasOpened) return;

        if (player.GetComponent<PlayerInventory>().inventoryObjects.Contains(neededItem))
        {
            if(door2 == null)
            {
                door1.Rotate(new Vector3(0, 90, 0));
                return;
            }
            else
            {
                door1.Rotate(new Vector3(0, 90, 0));
                door2.Rotate(new Vector3(0, -90, 0));

            }

            hasOpened = true;

            if (!isLevelChange) return;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            logCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (hasOpened) return;

        logCanvas.SetActive(false);
    }
}
