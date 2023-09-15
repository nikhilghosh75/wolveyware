using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreoManager : MonoBehaviour
{
    public List<Oreo> oreos;

    int numOreos = 0;

    // Start is called before the first frame update
    void Start()
    {
        numOreos = oreos.Count;
    }

    public void OreoDestroyed()
    {
        numOreos--;
        if(numOreos <= 0)
        {
            MinigameManager.MinigameFailure();
        }
    }
}
