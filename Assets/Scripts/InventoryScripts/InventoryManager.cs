using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryMenuCanvas; 
    public bool isInventoryActive = false; 
    public InventorySlotHandler inventorySlotHandlerPrefab; 
    [SerializeField] private Transform refrenceForIntantiation; 
    [SerializeField] private int numberOfSlots = 5; 
    private InventorySlotHandler[] inventorySlotsArray; 

    void Start()
    {
        if (inventorySlotHandlerPrefab != null && refrenceForIntantiation != null)
        {
            InstantiateItemSlotsArray(); 
        }
        else
        {
            Debug.LogError("Prefab or ItemPanel Transform is missing.");
        }
    }

    
    private void InstantiateItemSlotsArray()
    {
        
        inventorySlotsArray = new InventorySlotHandler[numberOfSlots];

        
        for (int i = 0; i < numberOfSlots; i++)
        {
           
            InventorySlotHandler newSlot = Instantiate(inventorySlotHandlerPrefab, refrenceForIntantiation);

            
            inventorySlotsArray[i] = newSlot;

            
            newSlot.transform.localPosition = new Vector3(0, i * 50, 0); 
            newSlot.name = "InventorySlot_" + i; 
        }
    }

    
    public void AddItem(string itemName, int maxQuantity, Sprite itemSprite)
    {
        Debug.Log("Item Name = " + itemName + " quantity = " + maxQuantity + " itemSprite = " + itemSprite);


        inventorySlotsArray[0].AddItem(itemName, maxQuantity, itemSprite);
    }

    
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
