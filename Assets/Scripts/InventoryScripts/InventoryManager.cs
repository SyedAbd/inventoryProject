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


    //public void AddItem(string itemName, int maxQuantity, Sprite itemSprite)
    //{
    //    Debug.Log("Item Name = " + itemName + " quantity = " + maxQuantity + " itemSprite = " + itemSprite);


    //    inventorySlotsArray[0].AddItem(itemName, maxQuantity, itemSprite);
    //}
    public void AddItem(string itemName, int maxQuantity, Sprite itemSprite, string itemDescription)
    {
        Debug.Log("Item Name = " + itemName + " quantity = " + maxQuantity + " itemSprite = " + itemSprite);
        for (int i = 0; i < inventorySlotsArray.Length; i++)
        {
            Debug.Log("Check name " + inventorySlotsArray[i].ItemName);
            if (inventorySlotsArray[i] != null && inventorySlotsArray[i].ItemName == itemName)
            {
                Debug.Log("same name found" + inventorySlotsArray[i].ItemName);
                inventorySlotsArray[i].AddItem( maxQuantity);
                return; 
            }
        }
        for (int i = 0; i < inventorySlotsArray.Length; i++)
        {
            if (inventorySlotsArray[i] == null || inventorySlotsArray[i].ItemName == "")
            {
               
                //inventorySlotsArray[i] = Instantiate(inventorySlotHandlerPrefab, refrenceForIntantiation);
                inventorySlotsArray[i].AddItem(itemName, maxQuantity, itemSprite, itemDescription);
                return;
            }
        }

        // If the inventory is full, provide feedback (optional)
        Debug.LogWarning("Inventory is full. Cannot add more items.");
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
    public void UnSelectAllSlots()
    {
        for (int i = 0;i < inventorySlotsArray.Length; i++)
        {
            inventorySlotsArray[i].selectedSlot.SetActive(false);
            inventorySlotsArray[i].isSeletctedPanel = false;
        }
    }
}
