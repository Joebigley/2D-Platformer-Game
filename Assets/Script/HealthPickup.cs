using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerHealth;

    public float healthBonus = 10f;
    public AudioSource audioSource;
    public Renderer rend;

    public CircleCollider2D circ;

   



    public void Awake()
    {
        
        playerHealth = FindObjectOfType<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();  
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        

        if (playerHealth.currenthealth < playerHealth.maxHealth) 
        {
            audioSource.Play();
            
            rend.enabled = false; // sets to false if hit.

            circ = GetComponent<CircleCollider2D>();

            circ.enabled = false;

            playerHealth.currenthealth = playerHealth.currenthealth + healthBonus;

            Destroy(gameObject, .2f);
            
        }

        
    }
}
