using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text reasonText;

    public void PopulateScreen(EndModeReason reason, int score)
    {
        gameObject.SetActive(true);

        highScoreText.gameObject.SetActive(false);
        scoreText.text = "Score: " + score.ToString();
        reasonText.text = ReasonToText(reason);
    }

    string ReasonToText(EndModeReason reason)
    {
        switch(reason)
        {
            case EndModeReason.Failure: return "You Failed";
            case EndModeReason.User: return "You Quit";
        }
        return "";
    }

    public void PlayAgain()
    {
        gameObject.SetActive(false);
        ModeManager.Instance.StartMode();
    }

    public void LoadMainMenu()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
