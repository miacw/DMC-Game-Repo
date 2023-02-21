using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mopedMovement : MonoBehaviour
{
    float speed;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        transform.RotateAround(transform.position, transform.up, 180f);
        speed = 17f;
        movement = new Vector3(0, 0, 1.5f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "BoatCollider")
        {
            transform.RotateAround(transform.position, transform.up, 180f);
            //movement = new Vector3(0, 0, -movement.z);
        }

    }
}
