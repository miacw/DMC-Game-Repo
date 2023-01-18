using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StallSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnObject", 0.1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];
       
        int boolInt = Random.Range(0, 2);

        if (boolInt == 1)
        {
            Instantiate(objectToSpawn, new Vector3(Random.Range(-6, 6), transform.position.y, transform.position.z), Quaternion.identity);
        }

    }
}
