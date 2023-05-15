using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marketMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        //transform.RotateAround(transform.position, transform.up, 180f);

        movement = new Vector3(1.5f, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * speed * Time.deltaTime);

    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BoatCollider")
        {
            //Debug.Log("Collided");
            Debug.Log(transform.eulerAngles);
            transform.RotateAround(transform.position, transform.up, 180f);
            //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + transform.localEulerAngles.y + 180, transform.localEulerAngles.z);
            Debug.Log(transform.eulerAngles);
            //movement = new Vector3(0, 0, -movement.z);
        }

    }*/

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BoatCollider")
        {
            Debug.Log("Collided market");
            //Debug.Log(transform.eulerAngles);
            transform.RotateAround(transform.position, transform.up, 180f);
            //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + transform.localEulerAngles.y + 180, transform.localEulerAngles.z);
            Debug.Log(transform.eulerAngles);
            //movement = new Vector3(0, 0, -movement.z);
        }

    }
}
