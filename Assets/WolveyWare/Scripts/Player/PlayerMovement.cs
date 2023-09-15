using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask groundLayerMask;
    public Vector2 groundCheckOffset;

    public float playerGroundSpeed;
    public float playerAirSpeed;

    public float playerJumpForce;
    public float playerDoubleJumpBufferTime;

    public bool canDoubleJump;

    Rigidbody2D rb;
    int numJumps;
    float lastJumpTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        bool isInAir = IsInAir();

        if (!isInAir)
            numJumps = 0;

        float speed = isInAir ? playerAirSpeed : playerGroundSpeed;
        if (Input.GetKey(KeyCode.A))
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        else if (Input.GetKey(KeyCode.D))
            rb.velocity = new Vector2(speed, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);

        float timeSinceLastJump = Time.time - lastJumpTime;
        if (Input.GetKeyDown(KeyCode.W) && timeSinceLastJump > playerDoubleJumpBufferTime)
        {
            if (!isInAir)
                Jump();
            else if (canDoubleJump && numJumps < 2)
                Jump();
        }
    }

    public bool IsInAir()
    {
        return Physics2D.OverlapPoint((Vector2)transform.position + groundCheckOffset, groundLayerMask) == null;
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, playerJumpForce);
        numJumps++;
        lastJumpTime = Time.time;
    }
}
