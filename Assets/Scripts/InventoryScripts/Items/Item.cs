using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int maxQuantity;

    [SerializeField]
    private Sprite thisSprite;

    [TextArea]
    [SerializeField]
    private string itemDescription;

    [SerializeField]
    private InventoryManager inventoryManagerObject;
    void Start()
    {
        inventoryManagerObject = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       //Debug.Log("Player hit");
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player hit");
            Debug.Log("Sprite :" + thisSprite);
            inventoryManagerObject.AddItem(itemName, maxQuantity, thisSprite, itemDescription);
            Destroy(gameObject);

        }
    }
}
