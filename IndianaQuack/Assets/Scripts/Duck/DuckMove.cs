using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMove : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;

    public float moveSpeed, rotSpeed;
    private float vert, horz;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Waddle();

        float absoluteVelocity = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.z);
        if (absoluteVelocity < 0.01F) anim.SetBool("Run", false);
        else anim.SetBool("Run", true);
    }

    void Waddle()
    {
        vert = Input.GetAxisRaw("Vertical");
        horz = Input.GetAxisRaw("Horizontal");

        rb.velocity = transform.forward * vert * moveSpeed * Time.fixedDeltaTime * -1;
        transform.Rotate((transform.up * horz) * rotSpeed * Time.fixedDeltaTime);
    }
}

