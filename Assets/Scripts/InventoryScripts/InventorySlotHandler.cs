using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class InventorySlotHandler : MonoBehaviour
{
    [SerializeField] private string itemName;
    public string ItemName
    {
        get { return itemName; }
    }


    public int maxQuantity;
    public Sprite itemSprite;
    public bool isFull;



    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image spritePlace;
    void Start()
    {
        
    }

    public void AddItem(string itemName, int maxQuantity, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.maxQuantity = maxQuantity;
        this.itemSprite = itemSprite;
        this.nameText.text = itemName;
        isFull = true;

        quantityText.text = maxQuantity.ToString();
        if (spritePlace == null)
        {
            Debug.LogError("spritePlace is not assigned!");
        }
        else
        {
            spritePlace.sprite = itemSprite;
        }
        //spritePlace.sprite = itemSprite;
    }
    public void AddItem(int maxQuantity) 
    {
        this.maxQuantity += maxQuantity;
        Debug.Log("New quantity " + this.maxQuantity);
        this.quantityText.text = this.maxQuantity.ToString();
        //quantityText.text = maxQuantity.ToString();
        //Remember to put in a check for max amount of items

    }
    
    void Update()
    {
        
    }
}
