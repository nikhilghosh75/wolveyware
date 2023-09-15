using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MinigameResultType
{
    FailureDefault,
    SuccessDefault
}

public class MinigameManager : MonoBehaviour
{
    [Header("Minigame Settings")]
    public string minigameName;
    public List<string> creators;
    public MinigameResultType resultType;

    [Header("Player Settings")]
    public bool hasGun;
    public bool hasMeleeAttack;

    bool succeeded = false;
    bool failed = false;

    public static MinigameManager Current { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        StartMinigame();
        Current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool HasSucceeded()
    {
        if (resultType == MinigameResultType.FailureDefault)
            return succeeded;
        else if (resultType == MinigameResultType.SuccessDefault)
            return !failed;

        return false;
    }

    void StartMinigame()
    {
        if(Player.Instance)
        {
            Player.Instance.SetGunEnabled(hasGun);
            Player.Instance.SetMeleeAttackEnabled(hasMeleeAttack);
        }
    }

    public static void MinigameSuccess()
    {
        Current.succeeded = true;
        if(ModeManager.Instance != null)
        {
            ModeManager.Instance.OnSuccess(Current);
        }
    }

    public static void MinigameFailure()
    {
        Current.failed = true;
        if (ModeManager.Instance != null)
        {
            ModeManager.Instance.OnFailure(Current);
        }
    }
}
