using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPanel : MonoBehaviour
{
    public Image itemImage;

    public Image panelImage;

    public TextMeshProUGUI panelText;

    public TextMeshProUGUI itemDesc;

    public int itemIndex;

    public GameObject player;

    private void Start()
    {
       

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player.GetComponent<PlayerInventory>().inventoryObjects.Count < 1) return;
        itemImage.sprite = player.GetComponent<PlayerInventory>().inventoryObjects[itemIndex].image;
    }

    public void SetMainPanelInfo()
    {
        panelImage.sprite = this.itemImage.sprite;
        panelText.text = player.GetComponent<PlayerInventory>().inventoryObjects[itemIndex].descText;
    }
}
