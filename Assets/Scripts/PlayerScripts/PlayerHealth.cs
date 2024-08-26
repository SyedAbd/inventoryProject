using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;        
    public float currentHealth;           
    public float healthDecayRate = 5f;    
    private bool isHealthDecreasing = false;

    void Start()
    {
        
        currentHealth = maxHealth;
    }

    void Update()
    {
        
        if (isHealthDecreasing)
        {
            Debug.Log("Health Decreasing " + currentHealth + "\n");
            currentHealth -= healthDecayRate * Time.deltaTime;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); 
        }

       
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    
    public void StartHealthDecay()
    {
        isHealthDecreasing = true;
    }

    public void Restore(float restorehealth)
    {
        if((currentHealth += restorehealth) <= 100) currentHealth += restorehealth;
        else currentHealth = maxHealth;
    }
    public void StopHealthDecay()
    {
        isHealthDecreasing = false;
    }

    
    private void Die()
    {
        Debug.Log("Player has died!");
        
    }
}
