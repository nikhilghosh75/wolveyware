using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackSource
{
    PlayerMelee,
    PlayerGun
}

[System.Serializable]
public class AttackInfo
{
    public Vector2 attackOrigin;
    public AttackSource attackSource;

    public AttackInfo(Vector2 _attackOrigin, AttackSource _attackSource)
    {
        attackOrigin = _attackOrigin;
        attackSource = _attackSource;
    }
}

public class Attackable : MonoBehaviour
{
    public virtual void OnAttack(AttackInfo info)
    {

    }
}
