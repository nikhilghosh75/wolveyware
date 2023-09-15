using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oreo : Attackable
{
    public OreoManager oreoManager;

    public override void OnAttack(AttackInfo info)
    {
        oreoManager.OreoDestroyed();
        Destroy(gameObject);
    }
}
