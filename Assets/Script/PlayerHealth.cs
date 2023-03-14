 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100;
    public float currenthealth;
    public Image healthBar;
    
    

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
    }


    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(currenthealth / maxHealth, 0, 1);
    }


    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
         

        

        if (currenthealth < 0)
        {
            Destroy(gameObject);

        }
        
    }
}
