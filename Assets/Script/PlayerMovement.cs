using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public PlayerController controller;
    public Animator animator; 
    
    float  horizontalMove = 0f;
    public float runSpeed = 40f;

    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
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
   
   
   
   
   void FixedUpdate() 
   {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
   }
}
