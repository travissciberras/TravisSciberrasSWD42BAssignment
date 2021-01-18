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

    public GameObject GetCarPrefab()
    {
        return carPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWayPoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
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
}
