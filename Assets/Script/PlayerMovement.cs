using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public PlayerController controller;
    public Animator animator;
    public Rigidbody2D rb;

    [Header("Knockback")]
    [SerializeField] private Transform _centre;
    [SerializeField] private float _knockbackVel = 8f;
    [SerializeField] private float _knockbackTime = 1f;
    [SerializeField] private bool _knockbacked;
    private SpriteRenderer[] _spriteRenderers;


    float  horizontalMove = 0f;
    public float runSpeed = 40f;

    bool jump = false;
    bool crouch = false;

    

    

    CircleCollider2D circleCollider;
    // Update is called once per frame
    
    
   
    
    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }
    void Update()
    {
        if(!_knockbacked) 
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }

        else
        {
            var LerpedXVelocity = Mathf.Lerp(rb.velocity.x, 0f, Time.deltaTime * 3);
            rb.velocity = new Vector2(LerpedXVelocity, rb.velocity.y);
        }
        
        

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
                jump = true;
                animator.SetBool("IsJumping", true);
            
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            circleCollider.offset = new Vector2 (circleCollider.offset.x, circleCollider.offset.y /2);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            circleCollider.offset = new Vector2(circleCollider.offset.x, circleCollider.offset.y * 2);
        }




    }

    //Aim mouse other side flips character
    //
    //Vector3 theScale = transform.localScale;
    //Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    //float WorldXPos = Camera.main.ScreenToWorldPoint(pos).x;
    //transform.position += movement * Time.deltaTime * moveSpeed;

    // if (WorldXPos > gameObject.transform.position.x)
    //{
    //   theScale.x = 1;
    //   transform.localScale = theScale;
    // }
    // else
    //  {
    //   theScale.x = -1;
    // transform.localScale = theScale;
    // }

    // }





    public void OnLanding()
    {
      animator.SetBool("IsJumping", false);
    }
   
    public void OnCrouching(bool isCrouching)
    {

        animator.SetBool("IsCrouching", isCrouching);
    }
   
   
   
   void FixedUpdate() 
   {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
   }

    public void Knockback(Transform t)
    {
        var dir = _centre.position - t.position;
        _knockbacked = true;
        rb.velocity = dir.normalized * _knockbackVel;
        foreach (var spriteRenderer in _spriteRenderers)
        {
            spriteRenderer.color = Color.red;
        }

        StartCoroutine(FadeToWhite());
        StartCoroutine(Unknockback());
    }

    private IEnumerator FadeToWhite()
    {
        while (_spriteRenderers[0].color != Color.white)
        {
            yield return null;
            foreach (var spriteRenderer in _spriteRenderers)
            {
                spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.white, Time.deltaTime * 3);
            }
        }
    }

    private IEnumerator Unknockback()
    {
        yield return new WaitForSeconds(_knockbackTime);
        _knockbacked = false;
    }
}
