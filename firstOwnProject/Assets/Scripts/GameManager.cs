using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;

    public static GameManager instance;
    public static int score = 0;

    int wave;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        score = 0;
        player = GameObject.Find("PlayerImage");
        SetWave(0);
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
