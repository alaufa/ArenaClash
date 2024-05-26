using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;  // Changed from true to false
    bool crouch = false;
    bool attack = false;
    bool jumpAttack = false;
    
    // Update is called once per frame
    void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (animator.GetBool("IsJumping"))
            {
                jumpAttack = true;
                animator.SetTrigger("JumpAttackTrigger");
                animator.SetBool("IsJumping", false);
    
            }
            else
            {
                attack = true;
                animator.SetTrigger("Attack");
            }
        }
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
