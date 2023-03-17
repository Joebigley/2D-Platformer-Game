using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public GameObject[] itemDrops;
    public int flickerAmnt;
    public float flickerDuration;
    public SpriteRenderer[] sprites;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        StartCoroutine(DamageFlicker());



        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            ItemDrop();
        }
    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }


    }

    IEnumerator DamageFlicker()
    {

        for (int i = 0; i < flickerAmnt; i++)
        {
            foreach (SpriteRenderer s in sprites)
            {
                s.color = new Color(1f, 1f, 1f, .6f);
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
