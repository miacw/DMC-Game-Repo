using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", 0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SpawnEnemy()
    {
        
        float randomTime = Random.Range(0,6);

        if(enemyToSpawn.name == "BusNewRotated2")
        {
            randomTime = Random.Range(7, 20);
        }
        else if(enemyToSpawn.name == "TrainNew")
        {
            randomTime = Random.Range(9, 18);
        }
        else
        {
            randomTime = Random.Range(0, 5);
        }
        

        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

        Invoke("SpawnEnemy", randomTime);

        
    }

   
}
