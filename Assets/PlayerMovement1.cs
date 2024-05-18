using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // To keep track of facing direction
    private bool facingRight = true;

    // Update is called once per frame
    void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump2"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        // Flip the character if needed
        Flip(horizontalMove);
    }

    void Flip(float moveDirection)
    {
        if (moveDirection > 0 && !facingRight)
        {
            // Right direction and currently facing left, flip the character
            facingRight = true;
            Vector3 theScale = transform.localScale;
            theScale.x = Mathf.Abs(theScale.x); // Ensure x is positive
            transform.localScale = theScale;
        }
        else if (moveDirection < 0 && facingRight)
        {
            // Left direction and currently facing right, flip the character
            facingRight = false;
            Vector3 theScale = transform.localScale;
            theScale.x = -Mathf.Abs(theScale.x); // Ensure x is negative
            transform.localScale = theScale;
        }
    }
}
