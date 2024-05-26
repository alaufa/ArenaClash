using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    public GameObject attackHitbox; // Reference to the attack hitbox GameObject

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool attack = false;
    bool jumpAttack = false;

    private bool facingRight = true;

    void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump2"))
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

        // if (Input.GetButtonDown("Fire1"))
        // {
        //     attack = true;
        //     animator.SetTrigger("Attack");
        // }

        if (Input.GetButtonDown("Fire1"))
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
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        Flip(horizontalMove);
    }

    void Flip(float moveDirection)
    {
        if (moveDirection > 0 && !facingRight)
        {
            facingRight = true;
            Vector3 theScale = transform.localScale;
            theScale.x = Mathf.Abs(theScale.x);
            transform.localScale = theScale;
        }
        else if (moveDirection < 0 && facingRight)
        {
            facingRight = false;
            Vector3 theScale = transform.localScale;
            theScale.x = -Mathf.Abs(theScale.x);
            transform.localScale = theScale;
        }
    }

    // Animation event methods
    public void EnableHitbox()
    {
        attackHitbox.SetActive(true);
    }

    public void DisableHitbox()
    {
        attackHitbox.SetActive(false);
    }
}