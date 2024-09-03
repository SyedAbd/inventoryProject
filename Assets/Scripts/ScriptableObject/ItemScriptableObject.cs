using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemSO", menuName = "Inventory/ItemSO")]
public class ItemScriptableObject : ScriptableObject
{ 

    public string itemName;
    public string description;
    public Sprite icon;
    public int quantity;
    public FunctionOfSO functionToPerform = new FunctionOfSO();
    public float changeStatsByThisAmount;

    public void UseItem()
    {

        if(functionToPerform == FunctionOfSO.hungerAndHealth)
        {
            GameObject.Find("Player").GetComponent<PlayerHunger>().RestoreHealthAndHunger(changeStatsByThisAmount);
        }


    }
    public enum FunctionOfSO
    {
        none,
        health,
        sleep,
        hunger,
        hungerAndHealth,
        sleepAndHealth,
    };
}

