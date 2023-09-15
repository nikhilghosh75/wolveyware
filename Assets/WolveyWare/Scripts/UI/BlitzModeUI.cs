using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlitzModeUI : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        int numMinigames = MinigameDatabase.Instance.minigames.Count;
        text.text = "You are about to play all " + numMinigames.ToString() + " minigames in this project";
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
