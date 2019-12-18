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
    public Vector3 spawnValues = new Vector3(14, 14, 0);
    public float minSpawnDistance = 5f;
    Camera cam;

    public static GameManager instance;
    public static int score = 0;


    GameObject player;
    float maxTimeBetweenSpawns = 1.0f;
    float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        lastSpawnTime = Time.time;
        score = 0;
        player = GameObject.Find("PlayerImage");
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time- lastSpawnTime > maxTimeBetweenSpawns)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), UnityEngine.Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);

        if (!IsOnScreen(spawnPosition)&& ((spawnPosition - player.transform.position).magnitude > minSpawnDistance))
        {
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            lastSpawnTime = Time.time;
        }
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

    public bool IsOnScreen(Vector3 position)
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        return onScreen;
    }
}
