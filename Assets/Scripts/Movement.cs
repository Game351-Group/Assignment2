using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 100f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Forward/backward movement
        float moveInput = Input.GetAxis("Vertical");
        Vector3 moveVelocity = transform.forward * moveInput * speed;
        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);

        // Turning left/right
        float turnInput = Input.GetAxis("Horizontal");
        rb.angularVelocity = new Vector3(0, turnInput * turnSpeed * Mathf.Deg2Rad, 0);
    }
}
