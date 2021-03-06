﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckJump : MonoBehaviour
{
    public LayerMask jumpables;
    public bool onGround, isJumping, isGliding;
    public float gravMultiplier;
    float currentGravity;
    public float startingGravity;
    float jumpTime = 0.4F;
    float jumpForce;
    public float startingJump;
    public float jumpAdditor = 5;
    public float glidingGrav;

    Rigidbody rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        currentGravity = startingGravity;
        jumpForce = jumpAdditor;
    }

    private void Update()
    {
        if (!onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("StartFly");
                anim.SetBool("Fly", true);
                rb.AddForce(Vector3.zero);
                isGliding = true;
                glidingGrav = startingGravity;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                anim.SetBool("Fly", false);
                rb.AddForce(Vector3.zero);
                isGliding = false;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (onGround)
        {
            Jump();
        }
        else
        {
            if (isJumping)
            {
                jumpTime -= Time.fixedDeltaTime;
                jumpForce += startingJump;
                rb.AddForce(new Vector3(0, jumpForce, 0));

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    isGliding = false;
                    anim.SetBool("Fly", false);
                }

                if (jumpTime < 0)
                {
                    isJumping = false;
                    jumpTime = 0.4F;
                    jumpForce = jumpAdditor;

                    if(isGliding) rb.AddForce(new Vector3(0, glidingGrav, 0));
                }
            }
            else
            {
                if (!isGliding)
                {
                    rb.AddForce(new Vector3(0, currentGravity, 0));
                    currentGravity *= gravMultiplier;
                }
                else
                {
                    rb.AddForce(new Vector3(0, glidingGrav, 0));
                    glidingGrav *= (gravMultiplier * 0.83F);
                }
            }
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && !isJumping && !isGliding)
        {
            onGround = false;
            isJumping = isGliding = true;
            currentGravity = startingGravity;
            anim.SetTrigger("StartFly");
            anim.SetBool("Fly", true);
        }

    }

    private void OnTriggerStay(Collider collision)
    {
        if ((jumpables & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            if (!isJumping)
            {
                onGround = true;
                isGliding = isJumping = false;
                currentGravity = glidingGrav = startingGravity;
                anim.SetBool("Fly", false);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if ((jumpables & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            onGround = false;
            //anim.SetBool("Fly", true);
        }
    }
}
