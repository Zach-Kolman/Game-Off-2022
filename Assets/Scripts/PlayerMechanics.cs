using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using StarterAssets;

public class PlayerMechanics : MonoBehaviour
{
    private CharacterController controller;
    private InputActionAsset originalInput;

    [HideInInspector]
    public StarterAssetsInputs inputAssets;

    private bool menuOpen = false;

    public GameObject InventoryCanvas;
    // Start is called before the first frame update

    private void Awake()
    {
        if (InventoryCanvas == null)
        {
            InventoryCanvas = GameObject.FindGameObjectWithTag("InventoryCanvas");
        }
    }
    void Start()
    {
        inputAssets = GetComponent<StarterAssetsInputs>();
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);

        if(inputAssets.menu)
        {
            if (!menuOpen)
            {
                menuOpen = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                InventoryCanvas.SetActive(true);
                
            }
            else
            {
                menuOpen = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                InventoryCanvas.SetActive(false);
                
            }

            inputAssets.menu = false;
        }
    }

    public void HaltControls()
    {
        controller.enabled = false;
    }

    public void RestoreControls()
    {
        controller.enabled = true;
    }
}
