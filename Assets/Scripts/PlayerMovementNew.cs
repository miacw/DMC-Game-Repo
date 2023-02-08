using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{

    private float playerSpeed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(new Vector3(1f, 0, 1.7f) * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(new Vector3(-1f, 0, 0) * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(new Vector3(1f, 0, 0) * playerSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision occured");

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
