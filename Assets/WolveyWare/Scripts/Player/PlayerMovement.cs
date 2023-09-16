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

    [SerializeField] bool grounded;

    bool APressed;
    bool DPressed;
    bool WPressed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        APressed = Input.GetKey(KeyCode.A);
        DPressed = Input.GetKey(KeyCode.D);
        WPressed = Input.GetKey(KeyCode.W);
    }

    void FixedUpdate()
    {
        bool isInAir = IsInAir();

        if (!isInAir)
            numJumps = 0;

        float speed = isInAir ? playerAirSpeed : playerGroundSpeed;
        if (APressed)
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        else if (DPressed)
            rb.velocity = new Vector2(speed, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);

        float timeSinceLastJump = Time.time - lastJumpTime;
        if (WPressed && timeSinceLastJump > playerDoubleJumpBufferTime)
        {
            if (!isInAir)
                Jump();
            else if (canDoubleJump && numJumps < 2)
                Jump();
        }

        grounded = !isInAir;
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
