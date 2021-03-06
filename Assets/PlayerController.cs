﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool facingRight = true;
    public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public Transform groundCheck;
    public float JumpForce = 1000f;

    bool grounded = false;
    Animator anim;
    Rigidbody2D rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb.velocity.x < maxSpeed)
            rb.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            anim.SetTrigger("isJump");
            rb.AddForce(new Vector2(0f, JumpForce));
            jump = false;
 
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1f;
        transform.localScale = theScale;
    }

    void Update () {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")); // bool type

        if (Input.GetButtonDown("Jump") && grounded)
            jump = true;


	}
}