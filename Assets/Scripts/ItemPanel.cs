using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPanel : MonoBehaviour
{
    [HideInInspector]
    //the image attached to this game object
    public Image itemPanelImage;


    //the image the panel displays
    public Image mainPanelImage;

    //the descriptive text the panel displays
    public TextMeshProUGUI mainPanelText;

    //the name text the panel displays
    public TextMeshProUGUI mainPanelName;


    public int itemIndex;

    private SimplePickup slottedItem;

    public GameObject player;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        itemPanelImage = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        
    }

    public void SetMainPanelInfo()
    {
        if (itemIndex > player.GetComponent<PlayerInventory>().inventoryObjects.Count - 1) return;
        mainPanelImage.sprite = player.GetComponent<PlayerInventory>().inventoryObjects[itemIndex].image;
        mainPanelText.text = player.GetComponent<PlayerInventory>().inventoryObjects[itemIndex].descText;
        mainPanelName.text = player.GetComponent<PlayerInventory>().inventoryObjects[itemIndex].nameText;
    }

    public void UnsetMainPanelInfo()
    {
        mainPanelImage.sprite = null;
        mainPanelText.text = "";
        mainPanelName.text = "";
    }
}
