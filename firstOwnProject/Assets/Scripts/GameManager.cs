using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float timeBetweenSpawns = 2.0f;
    float lastSpawnTime;

    public GameObject enemyPrefab;

    public static GameManager instance;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time- lastSpawnTime > timeBetweenSpawns)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform);
        lastSpawnTime = Time.time;
    }

    internal void SetGameOver()
    {
        Time.timeScale = 0f;
    }
}
