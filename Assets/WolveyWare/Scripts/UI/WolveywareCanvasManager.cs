using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolveywareCanvasManager : MonoBehaviour
{
    public GameOverScreen gameOverScreen;

    public static WolveywareCanvasManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
