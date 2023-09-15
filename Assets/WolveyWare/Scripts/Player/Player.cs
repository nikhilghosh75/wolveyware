using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerAttack playerAttack;
    PlayerGun playerGun;

    public static Player Instance { get; private set; }

    void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerGun = GetComponent<PlayerGun>();

        Instance = this;
    }

    public void SetGunEnabled(bool gunEnabled)
    {

    }

    public void SetMeleeAttackEnabled(bool meleeAttackEnabled)
    {
        if(meleeAttackEnabled)
        {
            playerAttack.enabled = true;
        }
        else
        {
            playerAttack.enabled = false;
            playerAttack.playerHitbox.gameObject.SetActive(false);
        }
    }
}
