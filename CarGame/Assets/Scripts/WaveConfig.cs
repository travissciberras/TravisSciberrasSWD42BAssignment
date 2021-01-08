using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Car Wave Config")]


public class WaveConfig : ScriptableObject
{
    //the enemy
    [SerializeField] GameObject carPrefab;
    //the path on which to go
    [SerializeField] GameObject pathPrefab;
    //time between each spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;
    //include this random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;
    //number of enemies in the wave
    [SerializeField] int numberOfCars = 5;
    //enemy movement speed
    [SerializeField] float carMoveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return carPrefab;
    }

    public GameObject GetPathPrefab()
    {
        return pathPrefab;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfCars;
    }

    public float GetEnemyMoveSpeed()
    {
        return carMoveSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
