using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    Collider2D col;

    public LayerMask attackLayermask;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    public void Activate()
    {
        Collider2D[] overlappingColliders = new Collider2D[10];
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.layerMask = attackLayermask;
        contactFilter.useLayerMask = true;

        int numColliders = Physics2D.OverlapCollider(col, contactFilter, overlappingColliders);
        for(int i = 0; i < numColliders; i++)
        {
            Attackable attackable = overlappingColliders[i].GetComponent<Attackable>();
            if(attackable != null)
            {
                attackable.OnAttack(new AttackInfo(transform.position, AttackSource.PlayerMelee));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool isInLayermask = ((attackLayermask.value >> other.gameObject.layer) % 2) == 1;
        if(isInLayermask)
        {
            Attackable attackable = other.GetComponent<Attackable>();
            if (attackable != null)
            {
                attackable.OnAttack(new AttackInfo(transform.position, AttackSource.PlayerMelee));
            }
        }
    }
}
