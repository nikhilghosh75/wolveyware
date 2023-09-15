using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlitzModeManager : ModeManager
{
    public float minigameTime = 8;
    public int startingLives = 1;

    Coroutine blitzModeCoroutine;
    bool minigameActive = true;
    int score = 0;
    int lives = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    IEnumerator BlitzMode()
    {
        int[] sceneIndices = PermutationUtil.Shuffle(PermutationUtil.IntArrayFromTo(1, SceneManager.sceneCountInBuildSettings));
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        for(int i = 0; i < sceneIndices.Length; i++)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndices[i]);
            operation.allowSceneActivation = false;

            yield return new WaitForSeconds(0.5f);

            operation.allowSceneActivation = true;
            SceneManager.UnloadSceneAsync(currentSceneIndex);
            currentSceneIndex = sceneIndices[i];

            yield return new WaitForSeconds(minigameTime);

            EndCurrentMinigame();
        }
    }

    public override void StartMode()
    {
        base.StartMode();
        blitzModeCoroutine = StartCoroutine(BlitzMode());
        score = 0;
        lives = startingLives;
    }

    public override void OnSuccess(MinigameManager manager)
    {
        score++;
    }

    public override void OnFailure(MinigameManager manager)
    {
        lives--;
        if(lives <= 0)
        {
            EndMode(EndModeReason.Failure, score);
        }
    }

    public override void OnModeEnded(EndModeReason reason)
    {
        StopCoroutine(blitzModeCoroutine);
    }
}
