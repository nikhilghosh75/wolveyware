using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MinigameModeUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string modeDescription;
    public TMP_Text modeText;
    public GameObject modeMenu;

    void Start()
    {
        modeText.gameObject.SetActive(false);
        modeMenu.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        modeText.gameObject.SetActive(true);
        modeText.text = modeDescription;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        modeText.gameObject.SetActive(false);
    }
}
