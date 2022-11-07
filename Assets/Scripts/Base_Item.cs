using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Base_Item : MonoBehaviour
{

    public SimplePickup itemType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;


        other.GetComponent<PlayerInventory>().inventoryObjects.Add(itemType);

        Destroy(this.gameObject);
    }
}


