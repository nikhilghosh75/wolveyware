using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndFourth : MonoBehaviour
{
    public float time;
    public Vector2 endOffset;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move()
    {
        Vector2 startPosition = transform.position;
        while(true)
        {
            float currentTime = 0;
            while(currentTime < time)
            {
                transform.position = Vector2.Lerp(startPosition, startPosition + endOffset, currentTime / time);
                yield return null;
                currentTime += Time.deltaTime;
            }

            currentTime = 0;
            while(currentTime < time)
            {
                transform.position = Vector2.Lerp(startPosition + endOffset, startPosition, currentTime / time);
                yield return null;
                currentTime += Time.deltaTime;
            }
        }
    }
}
