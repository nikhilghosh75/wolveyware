using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SingleMinigameModeUI : MonoBehaviour
{
    public GameObject minigameButtonPrefab;
    public Transform minigamesParent;
    public SingleMinigameManager manager;

    public TMP_Text nameText;
    public TMP_Text creditsText;

    // Start is called before the first frame update
    void Start()
    {
        foreach(MinigameDatabase.MinigameInfo info in MinigameDatabase.Instance.minigames)
        {
            GameObject spawnedButton = Instantiate(minigameButtonPrefab, minigamesParent);
            spawnedButton.GetComponent<MinigameButton>().SetMinigame(info, this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayMinigame(MinigameDatabase.MinigameInfo info)
    {
        string credits = "Made by ";
        for(int i = 0; i < info.credits.Count; i++)
        {
            credits += info.credits[i];
            if (i != info.credits.Count - 1)
                credits += ", ";
        }

        nameText.text = info.name;
        creditsText.text = credits;
    }

    public void UndisplayMinigame()
    {
        nameText.text = "";
        creditsText.text = "";
    }

    public void StartMinigame(MinigameDatabase.MinigameInfo info)
    {
        manager.info = info;
        manager.StartMode();
    }
}
