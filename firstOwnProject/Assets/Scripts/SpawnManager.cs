using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    public int maxEnemies;
}

public class SpawnManager : MonoBehaviour
{
    public Wave[] waves;
    public float timeBetweenWaves = 5f;
    public Vector3 spawnValues = new Vector3(14, 14, 0);
    public float minSpawnDistance = 5f;

    private GameObject player;
    private float lastSpawnTime;
    private int enemiesSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
        player = GameObject.Find("PlayerImage");
    }

    // Update is called once per frame
    void Update()
    {
        int currentWave = GameManager.instance.GetWave();

        if(currentWave<waves.Length)
        {
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;

            if (((enemiesSpawned==0 && timeInterval>timeBetweenWaves)||timeInterval>spawnInterval)&& enemiesSpawned<waves[currentWave].maxEnemies)
            {
                SpawnEnemy(currentWave);
            }

            if(enemiesSpawned==waves[currentWave].maxEnemies && GameObject.FindGameObjectWithTag("Enemy")==null)
            {
                WaveFinished();
            }
        }
        else
        {
            //GameManager.instance.SetGameOver();
            NoMoreWavesLeft();
        }
    }

    private void NoMoreWavesLeft()
    {
        float timeInterval = Time.time - lastSpawnTime;
        float spawnInterval = waves[waves.Length-1].spawnInterval;

        if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) || timeInterval > spawnInterval) && enemiesSpawned < (waves[waves.Length-1].maxEnemies*GameManager.instance.GetWave()-(waves.Length-1)))
        {
            SpawnEnemy(waves.Length-1);
        }

        if (enemiesSpawned >= waves[waves.Length-1].maxEnemies && GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            WaveFinished();
        }
    }

    private void SpawnEnemy(int currentWave)
    {
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), UnityEngine.Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
        if (!IsOnScreen(spawnPosition) && ((spawnPosition - player.transform.position).magnitude > minSpawnDistance))
        {
            lastSpawnTime = Time.time;
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(waves[currentWave].enemyPrefab, spawnPosition, spawnRotation);
            enemiesSpawned++;
        }
    }

    private void WaveFinished()
    {
        GameManager.instance.SetWave(GameManager.instance.GetWave() + 1);
        GameManager.instance.IncreaseScore(Mathf.RoundToInt(GameManager.instance.GetScore() * 0.1f));
        enemiesSpawned = 0;
        lastSpawnTime = Time.time;
    }

    public bool IsOnScreen(Vector3 position)
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        return onScreen;
    }
}
