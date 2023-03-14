using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerHealth;

    public float healthBonus = 10f;
    

    public void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(playerHealth.currenthealth < playerHealth.maxHealth) 
        { 
            Destroy(gameObject);
            playerHealth.currenthealth = playerHealth.currenthealth + healthBonus;
        }

        
    }
}
