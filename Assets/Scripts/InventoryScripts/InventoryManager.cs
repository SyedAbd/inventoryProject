using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryMenuCanvas;
    public bool isInventoryActive = false;
    public InventorySlotHandler inventorySlotHandler;
    void Start()
    {
        
    }


    public void AddItem(string itemName, int maxQuantity,Sprite itemSprite)
    {
        Debug.Log("Item Name = " + itemName + " quantity = " + maxQuantity + " itemSprite = "+ itemSprite);
        inventorySlotHandler.AddItem(itemName, maxQuantity, itemSprite);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory") && !isInventoryActive)
        {
            inventoryMenuCanvas.SetActive(true);
            Time.timeScale = 0;
            isInventoryActive = true;
        }
        else if (Input.GetButtonDown("Inventory") && isInventoryActive)
        {
            inventoryMenuCanvas.SetActive(false);
            Time.timeScale = 1;
            isInventoryActive = false;
        }
    }
}
