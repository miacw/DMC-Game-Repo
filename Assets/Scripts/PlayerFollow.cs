using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = player.transform.position + new Vector3(-140, 100, -10);
        transform.position = new Vector3(-819, 106, 260);
       


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(-140, 100, -10);


    }
}
