using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text HighscoreText;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        int Highscore=PlayerPrefs.GetInt("Highscore", 0);
        HighscoreText.text = "Highscore: " + Highscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        
    }
}
