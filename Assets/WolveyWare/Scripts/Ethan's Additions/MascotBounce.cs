using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MascotBounce : MonoBehaviour
{
    [SerializeField] float initialDirection;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Bounce");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Bounce()
    {
        float beatInterval = 60f / (float)ScoreTracker.bpm;
        float elapsedTime = 0f;
        for (int i = 0; i < 4; ++i)
        {
            elapsedTime = 0f;
            while (elapsedTime < beatInterval)
            {
                transform.position += Vector3.up * speed * initialDirection * Time.deltaTime;
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            elapsedTime = 0f;
            while (elapsedTime < beatInterval)
            {

                transform.position -= Vector3.up * speed * initialDirection * Time.deltaTime;
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

    }






}
