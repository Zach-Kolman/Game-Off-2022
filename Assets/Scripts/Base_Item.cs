using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro;

public class Base_Item : MonoBehaviour
{

    public SimplePickup itemType;

    public GameObject alertCanvas;

    private TextMeshProUGUI text;

    private Collider coll;

    public GameObject particleSystem;

    public List<GameObject> inventoryPanels;

    private void Start()
    {
        text = alertCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>();
        coll = gameObject.GetComponent<Collider>();

        foreach(GameObject gam in  GameObject.FindGameObjectsWithTag("InventoryPanel"))
        {
            inventoryPanels.Add(gam);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        other.GetComponent<PlayerInventory>().inventoryObjects.Add(itemType);

        foreach(GameObject gam in inventoryPanels)
        {
            if (gam.GetComponent<ItemPanel>().itemIndex == other.GetComponent<PlayerInventory>().inventoryObjects.Count - 1)
            {
                gam.GetComponent<ItemPanel>().itemPanelImage.sprite = itemType.image;
            }
        }

        StartCoroutine(SetCanvas());
    }

    IEnumerator SetCanvas()
    {
        alertCanvas.SetActive(true);
        text.text = itemType.nameText.ToString() + " has been aquired";

        particleSystem.SetActive(false);
        Destroy(coll);

        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }
}


