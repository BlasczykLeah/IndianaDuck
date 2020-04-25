using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMove : MonoBehaviour
{
    Rigidbody rb;

    public float moveSpeed, rotSpeed, jumpForce, fallSpeed;
    private float vert, horz;
    private float gravitationalConstant = 2.0f;
    public bool onGround;
    public float gravityScale = 1.0f;
    public static float globalGravity = -9.81f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Waddle();

        //Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        //rb.AddForce(gravity, ForceMode.Acceleration);

        /*if (onGround)
        {
            Jump();
        }
        else
        {
            float yVel = rb.velocity.y * gravityScale;
            rb.velocity = new Vector3(rb.velocity.x, yVel, rb.velocity.z);
        }*/
    }

    void Waddle()
    {
        vert = Input.GetAxisRaw("Vertical");
        horz = Input.GetAxisRaw("Horizontal");

        rb.velocity = transform.forward * vert * moveSpeed * Time.fixedDeltaTime * -1;
        transform.Rotate((transform.up * horz) * rotSpeed * Time.fixedDeltaTime);
    }

    void Jump()
    {
        float jumpVelocityUpwards = Mathf.Sqrt(gravitationalConstant * Mathf.Abs(Physics.gravity.y) * jumpForce);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpVelocityUpwards, rb.velocity.z);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}

