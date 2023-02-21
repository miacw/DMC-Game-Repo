using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public GameObject gameController;
    
    

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject,0.25f);
            endGame("MainMenu");
        }
        else if(collision.gameObject.tag == "Water" && collision.gameObject.tag != "Lilypad")
        {
            
            Destroy(gameObject);
            endGame("MainMenu");
        }
        //else if(collision.gameObject.tag == "Lilypad")
        //{
           // Debug.Log("standing on Lilypad");
            //gameController.GetComponent<GameController>().IncreaseScore(1);

           // player.GetComponent<PlayerScore>().playerScore += 1;
           // player.GetComponent<PlayerScore>().SetScore(player.GetComponent<PlayerScore>().playerScore);
            
        //}


        
    }

    public void endGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

   



}
