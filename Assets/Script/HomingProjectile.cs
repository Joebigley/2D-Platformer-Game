using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class HomingProjectile : MonoBehaviour
{


    public Transform target;

    public float speed = 5f;
    public float rotateSpeed = 200f;

    private Rigidbody2D rb;

    public Renderer rend;

    public Collider2D Col;
    public float lifetime = 3.0f;



    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        
    }




    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            rend.enabled = false; // sets to false if hit.

            Col = GetComponent<Collider2D>();

            Col.enabled = false;

            Destroy(gameObject, 1f);
        }

        if (other.gameObject.CompareTag("Platform"))
        {

            Destroy(gameObject);
        }

        Destroy(gameObject, lifetime);

    }
}