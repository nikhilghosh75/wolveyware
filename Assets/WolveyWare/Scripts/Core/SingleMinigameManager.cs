using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleMinigameManager : ModeManager
{
    [HideInInspector]
    public MinigameDatabase.MinigameInfo info;

    public override void StartMode()
    {
        base.StartMode();

        SceneManager.LoadSceneAsync(info.sceneName);
    }

    IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(8f);
    }

    public override void OnFailure(MinigameManager manager)
    {
        EndMode(EndModeReason.Default, 0);
    }

    public override void OnModeEnded(EndModeReason reason)
    {
        
    }

    public override void OnSuccess(MinigameManager manager)
    {
        EndMode(EndModeReason.Default, 1);
    }
}
