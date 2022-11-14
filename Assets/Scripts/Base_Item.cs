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

    private void Start()
    {
        text = alertCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>();
        coll = gameObject.GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        other.GetComponent<PlayerInventory>().inventoryObjects.Add(itemType);

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


