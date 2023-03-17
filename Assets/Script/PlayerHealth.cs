 using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100;
    public float currenthealth;
    public Image healthBar;

    public int flickerAmnt;
    public float flickerDuration;
    public SpriteRenderer[] sprites;




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
        StartCoroutine(DamageFlicker());


        if (currenthealth < 0)
        {
            Destroy(gameObject);

        }

    }

    IEnumerator DamageFlicker()
    {

        for (int i = 0; i < flickerAmnt; i++)
        {
            foreach (SpriteRenderer s in sprites)
            {
                s.color = new Color(1f, 1f, 1f, .5f);
            }
            yield return new WaitForSeconds(flickerDuration);
            foreach (SpriteRenderer s in sprites)
            {
                s.color = Color.white;
            }
            yield return new WaitForSeconds(flickerDuration);

        }

    }
}
