using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMove : MonoBehaviour
{
    Rigidbody rb;

    public float moveSpeed, rotSpeed;
    private float vert, horz;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Waddle();
    }

    void Waddle()
    {
        vert = Input.GetAxisRaw("Vertical");
        horz = Input.GetAxisRaw("Horizontal");

        rb.velocity = transform.forward * vert * moveSpeed * Time.fixedDeltaTime * -1;
        transform.Rotate((transform.up * horz) * rotSpeed * Time.fixedDeltaTime);
    }
}

