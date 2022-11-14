using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPanel : MonoBehaviour
{
    //the image attached to this game object
    public Image itemImage;

    [HideInInspector]
    public TextMeshProUGUI itemDesc;
    [HideInInspector]
    public TextMeshProUGUI itemName;

    //the image the panel displays
    public Image panelImage;

    //the descriptive text the panel displays
    public TextMeshProUGUI panelText;

    //the name text the panel displays
    public TextMeshProUGUI panelName;

    public int itemIndex;

    public GameObject player;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (itemIndex > player.GetComponent<PlayerInventory>().inventoryObjects.Count - 1) return;
        itemImage.sprite = player.GetComponent<PlayerInventory>().inventoryObjects[itemIndex].image;
    }

    public void SetMainPanelInfo()
    {
        panelImage.sprite = this.itemImage.sprite;
        itemDesc.text = player.GetComponent<PlayerInventory>().inventoryObjects[itemIndex].descText;
        itemName.text = player.GetComponent<PlayerInventory>().inventoryObjects[itemIndex].nameText;
    }

    public void UnsetMainPanelInfo()
    {
        panelImage.sprite = null;
        itemDesc.text = "";
        itemName.text = "";
    }
}
