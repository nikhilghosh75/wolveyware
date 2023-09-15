using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public LayerMask attackLayermask;
    public bool destroyOnHit;

    private void OnCollisionEnter2D(Collision2D col)
    {
        bool isInLayermask = ((attackLayermask.value >> col.gameObject.layer) % 2) == 1;
        if (isInLayermask)
        {
            Attackable attackable = col.gameObject.GetComponent<Attackable>();
            if (attackable != null)
            {
                attackable.OnAttack(new AttackInfo(transform.position, AttackSource.PlayerGun));
                if (destroyOnHit)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
