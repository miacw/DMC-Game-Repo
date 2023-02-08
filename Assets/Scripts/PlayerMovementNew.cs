using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementNew : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rb;
    public float jumpForce = 20;
    public float gravity = -9.81f;
    public float gravityScale = 5;
    float velocity;
    public Animator playerAnimator;
    bool jumping;
    public bool isGrounded;




   
    private float jumpHeight = 1.5f;


    private float playerSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        jumping = false;
       
        

    }

    // Update is called once per frame
    void Update()
    {

        


        // forward/back/left/right controls
        if (Input.GetKey("w"))
        {
            //transform.Translate(new Vector3(1f, 0, 1.7f) * playerSpeed * Time.deltaTime);
            //rb.constraints = RigidbodyConstraints.FreezeRotation;
            //rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.velocity = new Vector3(1.5f, 0, 1.5f) * playerSpeed * Time.deltaTime;
            
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(new Vector3(-1f, 0, 0) * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(new Vector3(1f, 0, 0) * playerSpeed * Time.deltaTime);
        }

        //velocity += gravity * gravityScale * Time.deltaTime;
        //if(isGrounded && velocity < 0)
        //{
        //  velocity = 0;
        //}

        // jump controls


        


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                jumping = true;
                rb.velocity = new Vector3(0, 1f, 0) * jumpForce * Time.deltaTime;
                
            }
            //transform.Translate(new Vector3(0, 2f, 0) * 5 * Time.deltaTime);
            //rb.velocity = new Vector3(0, 1f, 0) * jumpForce * Time.deltaTime;
            // jumping = true;

            // rb.AddForce(Vector3.up * jumpForce * Time.deltaTime);
            //playerAnimator.SetBool("jump", true);

            //velocity = jumpForce;
            
        }

        //transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);


        if (jumping)
        {
            //isGrounded = false;
            //velocity += gravity * gravityScale * Time.deltaTime;
            //rb.velocity = new Vector3(0, velocity, 0);
            //rb.velocity = new Vector3(0, -1f, 0) * -9 * Time.deltaTime;
            //rb.AddForce(Vector3.down * 9 * Time.deltaTime);
            //jumping = false;
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

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            jumping = false;
            Debug.Log("Grounded");

        }
    }
}
