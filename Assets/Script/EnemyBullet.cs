using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;

    public Renderer rend;

    public Collider2D Col;

   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
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

            rend.enabled = false; // sets to false if hit.

            Col = GetComponent<Collider2D>();

            Col.enabled = false;

            Destroy(gameObject, 1f);
        }

    }
}
