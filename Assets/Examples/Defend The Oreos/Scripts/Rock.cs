using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Attackable
{
    public float pushForce;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void OnAttack(AttackInfo info)
    {
        Vector2 diff = (Vector2)transform.position - info.attackOrigin;
        rb.AddForce(diff.normalized * pushForce, ForceMode2D.Impulse);

        GetComponent<Collider2D>().enabled = false;
    }
}
