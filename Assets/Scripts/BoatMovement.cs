using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    float speed;
    Vector3 movement;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        speed = 13f;
        movement = new Vector3(0, 0, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(movement * speed * Time.deltaTime);
        rb.velocity = movement * speed * Time.deltaTime;
        //rb.AddForce(1.5f, 0, 0);

    }

    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.gameObject.tag == "BoatCollider")
        {
            movement = new Vector3(0, 0, -movement.z);
        }
        
    }
}
