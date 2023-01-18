using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class padSpawner : MonoBehaviour

 
{

    [SerializeField] private GameObject lilypad;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnLilypad", 0.1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnLilypad()
    {
        for (float i = 1; i <= Random.Range(1, 3); i++)
        {
            Instantiate(lilypad, new Vector3(Random.Range(-4,4), transform.position.y, transform.position.z), Quaternion.identity);
        }

    }
}
