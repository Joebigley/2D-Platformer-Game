using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
  public float speed;
  public float lifeTime;
    //public GameObject destroyEffect;
  public float timer;
  public Transform Player;
  
    void Start()
     {
        //Invoke("DestroyProjectile", lifeTime);
        Player = Player.transform;
    }
    
    
    private void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        //timer += 1.0F * Time.deltaTime;

        //if (timer >= 3)
        //{
        //  GameObject.Destroy(gameObject);
        //}
        if (timer >= 3)
        {
            GameObject.Destroy(gameObject);
        }
        //DestroyProjectile();
        //GameObject clone =  Instantiate(destroyEffect, transform.position, Quaternion.identity);
        //Destroy(clone, 3);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
            Destroy(gameObject);

        }

        if(collision.collider.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }

        



    }

  









    /*void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }*/
}
