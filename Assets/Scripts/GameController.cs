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
    public GameObject loseMenu;
    public GameObject winMenu;
    public GameObject soundoff;
    public GameObject audioPlayer;
    
    private CanvasGroup pauseCanvas;
    public int score;
    public static bool gameIsPaused;
    public bool isMute;
    
    // Start is called before the first frame update
    void Start()
    {
        //highscoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
        Time.timeScale = 1f;
        score = 0;
        pauseCanvas = pauseMenu.GetComponent<CanvasGroup>();
        //pauseCanvas.alpha = 0;

        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //gameIsPaused = !gameIsPaused;
            PauseGame(true);
            
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

    public void PauseGame(bool paused)
    {
        if (paused )
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            
        }
        else
        {
            
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;

        }
    }

    public void pauseSound(bool muted)
    {
        if (muted)
        {
            soundoff.SetActive(true);
            audioPlayer.GetComponent<AudioSource>().volume = 0;

        }
        else
        {
            soundoff.SetActive(false);
            audioPlayer.GetComponent<AudioSource>().volume = 1;

        }
        
    }

    public void LoseGame()
    {
        loseMenu.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void WinGame()
    {
        winMenu.SetActive(true);
        //Time.timeScale = 0f;
    }
}
