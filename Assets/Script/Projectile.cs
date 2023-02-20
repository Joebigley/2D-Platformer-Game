using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  public float speed;
  public float lifeTime;
  public GameObject destroyEffect;
    

    private void start()
        {
            Invoke("DestroyProjectile", lifeTime);
        }
    
    
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        DestroyProjectile();
    }

    void DestroyProjectile()
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
             Destroy(gameObject);
        }

     

}
