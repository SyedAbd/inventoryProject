using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryMenuCanvas;
    public bool isInventoryActive = false;
    void Start()
    {
        
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
