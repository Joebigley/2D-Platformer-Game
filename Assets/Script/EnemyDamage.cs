using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    
    public int damage;
    public PlayerHealth playerHealth;
    public AudioSource audioSource;
    




    private void Start()
    {
        
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
            audioSource.Play();
        }
    
        
    
    }
}
