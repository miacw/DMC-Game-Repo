using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScore : MonoBehaviour
{
    // public int playerScore;
    // [SerializeField] Text scoreText;

    public GameObject gameController;
    
    // Start is called before the first frame update

    
    
    void Start()
    {
       //  playerScore = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            //collision.gameObject.GetComponent<AudioSource>().Play();
            /*
            playerScore += 2;
            SetScore(playerScore);
            */

            gameController.GetComponent<GameController>().IncreaseScore(2);
            
            Destroy(collision.gameObject, 0.4f);
            
        }
        
    }

   /* public void SetScore(int score)
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }
   */

   
}
