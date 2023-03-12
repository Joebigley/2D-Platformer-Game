 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100;
    public float health;
    public Image healthBar;
    
    

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }


    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
         

        

        if (health < 0)
        {
            Destroy(gameObject);

        }
        
    }
}
