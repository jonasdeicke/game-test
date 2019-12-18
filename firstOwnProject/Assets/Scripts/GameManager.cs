using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Text scoreText;
       
    public static GameManager instance;
    public static int score = 0;

    float timeBetweenSpawns = 2.0f;
    float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        lastSpawnTime = Time.time;
        score = 0;
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
        if(PlayerPrefs.GetInt("Highscore")<score)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        SceneManager.LoadScene(0);
        Time.timeScale = 0f;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: "+score;
    }
}
