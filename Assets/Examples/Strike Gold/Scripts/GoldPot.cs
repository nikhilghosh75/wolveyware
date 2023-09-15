using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldPot : Attackable
{
    public Slider goldProgressBar;

    public float minAttackForce;
    public float maxAttackForce;

    [Header("Gold Settings")]
    public GameObject goldPrefab;

    public int minGoldCoins;
    public int maxGoldCoins;
    public float maxVelocity;
    public float minCoinForce;
    public float maxCoinForce;

    Rigidbody2D rb;
    int goldCollected;
    int goldGoal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        goldCollected = 0;
        goldGoal = Random.Range(15, 25);
    }

    public override void OnAttack(AttackInfo info)
    {
        base.OnAttack(info);

        int coinsToDrop = (int)Mathf.Lerp(minGoldCoins, maxGoldCoins, rb.velocity.magnitude / maxVelocity);
        goldCollected += coinsToDrop;
        goldProgressBar.value = (float)goldCollected / (float)goldGoal;
        if (goldCollected >= goldGoal)
            MinigameManager.MinigameSuccess();

        for(int i = 0; i < coinsToDrop; i++)
        {
            float randX = Random.Range(-2f, 2f);
            Vector2 forceDirection = (new Vector2(randX, 1f)).normalized;
            float forceMagnitude = Random.Range(minCoinForce, maxCoinForce);

            GameObject gold = Instantiate(goldPrefab, transform.position, Quaternion.identity);
            gold.GetComponent<Rigidbody2D>().AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
        }

        Vector2 diff = (Vector2)transform.position - info.attackOrigin;
        rb.AddForce(diff.normalized * Random.Range(minAttackForce, maxAttackForce), ForceMode2D.Impulse);
    }
}
