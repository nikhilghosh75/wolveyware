using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerHitbox playerHitbox;

    public bool attackEnabled;
    public float attackLength;

    PlayerAnimator playerAnimator;

    bool isAttacking = false;
    public bool IsAttacking => isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();

        playerHitbox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!attackEnabled)
            return;

        if (isAttacking)
            return;

        if (Input.GetMouseButton(0))
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        playerHitbox.gameObject.SetActive(true);
        playerHitbox.Activate();

        playerAnimator.PlayAttackAnimation();

        yield return new WaitForSeconds(attackLength);

        playerHitbox.gameObject.SetActive(false);
        isAttacking = false;
    }
}
