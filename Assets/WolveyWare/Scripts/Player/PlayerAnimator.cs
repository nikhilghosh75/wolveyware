using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerAttack playerAttack;
    Animator animator;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleFlipping();

        if(playerMovement.IsInAir())
        {
            animator.SetBool("in_air", true);
        }
        else
        {
            animator.SetBool("in_air", false);
            animator.SetBool("is_moving", rb.velocity.magnitude > 0.1f);
            animator.SetFloat("direction", rb.velocity.x);
        }
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    void HandleFlipping()
    {
        if(!playerAttack.IsAttacking && Mathf.Abs(rb.velocity.x) > 0.4f)
        {
            transform.localScale = rb.velocity.x > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
        }
    }
}
