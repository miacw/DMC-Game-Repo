using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{

    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<GameObject> terrains = new List<GameObject>();
    [SerializeField] private GameObject player;

    private List<GameObject> currentTerrains = new List<GameObject>();
    private Vector3 currentPosition = new Vector3(0, 0, 0);
    private Vector3 playerCurrentPosition;
    private Vector3 playerPreviousPosition;

    // Start is called before the first frame update
    void Start()
    {
       
        playerPreviousPosition = player.transform.position;
        playerCurrentPosition = player.transform.position;


        for (int i=0; i < 8; i++)
        {
            SpawnTerrain();
        }
        
    }

    // Update is called once per frame
    void Update()
    {


       
        if(player.transform.position.z > playerPreviousPosition.z + 5)
            {
                SpawnTerrain();
                playerPreviousPosition = player.transform.position;
        }
        
        
        
        

        
        
    }


    private void SpawnTerrain()
    {
        GameObject terrain = Instantiate(terrains[Random.Range(0, terrains.Count)], currentPosition, Quaternion.identity); //has to give rotation to vector 3, in this case no rotation
        currentTerrains.Add(terrain);

        if(currentTerrains.Count > maxTerrainCount)
        {
            Destroy(currentTerrains[0]);
            currentTerrains.RemoveAt(0);
        }

        currentPosition.z += 5;
    }
}
