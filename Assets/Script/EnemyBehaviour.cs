using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] float movespeed = 1f;

   float speed = 1f;

     Rigidbody2D rb;


    BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {


        if (isfacingright())
        {


            rb.velocity = new Vector2(-speed, 0f);
        }
        else
        {

            rb.velocity = new Vector2(speed, 0f);



        }
    }


    bool isfacingright()
    {



        return transform.localScale.x > Mathf.Epsilon;
    }


    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "tilemap" )
        {
            transform.localScale = new Vector2((Mathf.Sign(rb.velocity.x)), transform.localScale.y);
        }
    }
}