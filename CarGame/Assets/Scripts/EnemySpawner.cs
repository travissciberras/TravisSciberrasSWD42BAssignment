using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;

    int startingWave = 0;

    public Transform[] SpawnPoints;

    public GameObject enemySpawner;

    [SerializeField] bool loop = false;
    // Start is called before the first frame update

    //void Start()
    //{
    //    var currentWave = waveConfigs[startingWave];

    //    StartCoroutine(SpawnAllCarsInWave(currentWave));
    //}

    IEnumerator Start()
    {
        //int RandomIndex = (GameObject.FindGameObjectsWithTag("Spawnable")0, SpawnPoints.Length);

        //for (int i = 0; i < SpawnPoints.Length; i++)

        //{
        //    if (RandomIndex != i)
        //    {
        //        Instantiate(enemySpawner, SpawnPoints[i].position, Quaternion.identity);

        //    }

        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (loop);
    }

    private IEnumerator SpawnAllCarsInWave(WaveConfig waveConfig)
    {
        for (int EnemyCount = 1; EnemyCount <= waveConfig.GetNumberOfEnemies(); EnemyCount++)
        {
            //spawn the car from waveConfig
            //at the position specified by the waveConfig waypoints
            var newCar = Instantiate(
                waveConfig.GetCarPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);

            newCar.GetComponent<PathFollow>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }

    }

    private IEnumerator SpawnAllWaves()
    {
        foreach (WaveConfig currentWave in waveConfigs)
        {
            //var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllCarsInWave(currentWave));

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //void placespawner()
    //{
    //    for(int i = 0; i<5; i++)
    //    {

    //    }
    //}
}