using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class InventorySlotHandler : MonoBehaviour
{
    public string itemName;
    public int maxQuantity;
    public Sprite itemSprite;
    public bool isFull;



    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image spritePlace;
    void Start()
    {
        
    }

    public void AddItem(string itemName, int maxQuantity, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.maxQuantity = maxQuantity;
        //this.itemSprite = itemSprite;
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
        spritePlace.sprite = itemSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
