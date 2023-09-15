using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinigameButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector]
    SingleMinigameModeUI singleMinigameMode;

    [SerializeField] TMP_Text text;

    MinigameDatabase.MinigameInfo info;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMinigame(MinigameDatabase.MinigameInfo _info, SingleMinigameModeUI _minigameMode)
    {
        info = _info;
        text.text = info.name;
        singleMinigameMode = _minigameMode;
    }

    public void StartMinigame()
    {
        singleMinigameMode.StartMinigame(info);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        singleMinigameMode.DisplayMinigame(info);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        singleMinigameMode.UndisplayMinigame();
    }
}
