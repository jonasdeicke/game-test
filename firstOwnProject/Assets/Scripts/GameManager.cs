using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text waveText;

    public static GameManager instance;
    public static int score = 0;
    public static int wave = 0;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        score = 0;
        SetWave(0);
        player = GameObject.Find("PlayerImage");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetWave()
    {
        return wave;
    }

    public void SetWave(int value)
    {
        wave = value;
        if (waveText != null)
        {
            waveText.text = "Wave: " + (wave + 1);
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

    public void IncreaseScore(int value)
    {
        score+=value;
        scoreText.text = "Score: "+score;
    }

    public int GetScore()
    {
        return score;
    }
}
