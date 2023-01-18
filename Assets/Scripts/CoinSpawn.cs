using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private GameObject coinToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCoins();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCoins()
    {
        int boolInt = Random.Range(0, 4);
        
        if (boolInt == 1)
        {
            Instantiate(coinToSpawn, new Vector3(Random.Range(-5, 5), transform.position.y, transform.position.z), Quaternion.identity);
        }

    }
}
