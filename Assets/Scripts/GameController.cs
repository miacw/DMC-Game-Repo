using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text playerScoreText;
    public Text highscoreText;
    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int increase)
    {
        score += increase;
        playerScoreText.text = "Score: " + score;

        if(score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
            highscoreText.text = "High Score: " + score.ToString();
        }
        
    }
}
