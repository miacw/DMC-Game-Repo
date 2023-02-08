using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    float speed;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
        movement = new Vector3(1.5f, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "BoatCollider")
        {
            movement = new Vector3(-movement.x, 0, 0);
        }
        
    }
}
