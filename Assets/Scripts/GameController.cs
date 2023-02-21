using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameController : MonoBehaviour
{
    //public Text playerScoreText;
    public TMP_Text playerScoreText;
    public Text highscoreText;
    public GameObject pauseMenu;
    private CanvasGroup pauseCanvas;
    public int score;
    public static bool gameIsPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        //highscoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
        score = 0;
        pauseCanvas = pauseMenu.GetComponent<CanvasGroup>();
        pauseCanvas.alpha = 0;
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
            
        }
        
    }

    public void IncreaseScore(int increase)
    {
        score += increase;
        playerScoreText.text =  score.ToString();

        //if(score > PlayerPrefs.GetInt("highScore"))
        //{
          //  PlayerPrefs.SetInt("highScore", score);
           // highscoreText.text = "High Score: " + score.ToString();
        //}
        
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pauseCanvas.alpha = 1;
            
        }
        else
        {
            
            Time.timeScale = 1f;
            pauseCanvas.alpha = 0;

        }
    }
}
