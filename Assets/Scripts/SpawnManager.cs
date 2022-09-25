using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private float spawnRangeX = 34;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 2.0f, 2.0f);
    }

    void SpawnAsteroid()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, 100);
        int asteroidIndex = Random.Range(0, asteroidPrefabs.Length);
        Instantiate(asteroidPrefabs[asteroidIndex], spawnPos, asteroidPrefabs[asteroidIndex].transform.rotation);

    }
}
