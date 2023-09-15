using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public float spawnTime;
    public float spawnTimeVariation;
    public int numToSpawn;

    public float minSpeed;
    public float maxSpeed;

    public GameObject rock;
    public float spawnX;
    public float spawnMinY;
    public float spawnMaxY;
    public Vector2 spawnDirection;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRocks());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRocks()
    {
        for(int i = 0; i < numToSpawn; i++)
        {
            yield return new WaitForSeconds(spawnTime + Random.Range(-spawnTimeVariation, spawnTimeVariation));

            Vector2 spawnPoint = new Vector2(spawnX, Random.Range(spawnMinY, spawnMaxY));

            GameObject spawnedRock = Instantiate(rock, spawnPoint, Quaternion.identity);
            spawnedRock.GetComponent<ProjectileMovement>().speed = Random.Range(minSpeed, maxSpeed);
            spawnedRock.GetComponent<ProjectileMovement>().direction = spawnDirection;
        }
    }
}
