using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRB : MonoBehaviour
{
    private const float Y = 1f;
    public float speed = 20f;
    public float jumpHeight = 2f;
   
    public Vector3 boxSize;
    public LayerMask layerMask;
    public Vector3 jump;
    private Transform marginY;
    public float jumpForce = 2.0f;
    [SerializeField] float gravity;

    private Rigidbody rb;
    private Vector3 inputs = Vector3.zero;
    private float yVel;
    private bool isGrounded = false;
    private Transform groundChecker;

    Vector3 boatSpeed;

    Animator animator;

    private bool isWalking;
    private bool isJumping;

    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 6f, 0.0f);
        //groundChecker = transform.GetChild(0);
        isWalking = false;
        isJumping = false;
        animator = GetComponent<Animator>();
        boatSpeed = new Vector3(0, 0, 0);



    }

    // Update is called once per frame
    void Update()
    {
       

        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Vertical") * speed;
        inputs.z = -Input.GetAxis("Horizontal") * speed;

        if (inputs != Vector3.zero)
        {
            if (isJumping)
            {
                animator.SetBool("walking", false);
            }
            else
            {
                animator.SetBool("walking", true);

            }

            rb.isKinematic = false;
            transform.forward = inputs;
        }
        else
        {
            animator.SetBool("walking", false);
        }
        //Debug.Log("is grounded: " + isGrounded);
        // player jumping
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            yVel = jumpForce;
            //rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            
            isJumping = true;



            animator.SetBool("walking", false);


            animator.SetBool("jump", true);

        }
        else if (isGrounded)
        {
            yVel = 9.81f;
        }
        else
        {
            yVel -= gravity * Time.deltaTime * 100;
        }
        //Debug.Log(yVel);

        inputs.y = yVel;




    }




    private void FixedUpdate()
    {
        // player movement
        rb.velocity = (inputs + boatSpeed) * Time.fixedDeltaTime;

        //rb.MovePosition(rb.position + inputs * speed * Time.fixedDeltaTime);
        // rb.velocity = inputs * Time.fixedDeltaTime;





    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            yVel = 0;
            isGrounded = true;
            isJumping = false;
            animator.SetBool("jump", false);


        }

        if(collision.gameObject.tag == "BoatCollider")
        {
            isGrounded = true;
            isJumping = false;
            animator.SetBool("jump", false);

            boatSpeed = collision.transform.GetComponent<Rigidbody>().velocity * collision.transform.GetComponent<BoatMovement>().speed;
            Debug.Log(boatSpeed);
        }

        if(collision.gameObject.tag == "Lilypad")
        {
            isGrounded = true;
            isJumping = false;
            animator.SetBool("jump", false);
        }
        if (collision.gameObject.tag == "Water" && collision.gameObject.tag != "Lilypad" )
        {

            Destroy(gameObject);
            gameController.GetComponent<GameController>().LoseGame();

        }

        Debug.Log(collision.gameObject.tag);
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "BoatCollider")
        {
            boatSpeed = Vector3.zero;
        }


    }

   



    /*  private void OnTriggerStay(Collider other)
      {
          if (other.gameObject.tag == "BoatCollider")
          {

              isGrounded = true;
              //rb.isKinematic = true;
              //transform.parent = other.transform;

          }

      }

      private void OnTriggerExit(Collider other)
      {
          if (other.gameObject.tag == "BoatCollider")
          {
              isGrounded = false;
          }
      }
    */
    /*private void OnTriggerStay(Collider trigger)
    { 
        if(trigger.gameObject.tag == "BoatCollider")
        {

                transform.parent = trigger.gameObject.transform;




            /*Vector3 boatPos = new Vector3(trigger.transform.position.x + 1f, trigger.transform.position.y + 30f, trigger.transform.position.z - 30f);
        rb.position = boatPos;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.position = boatPos + new Vector3(55f, 0, 0);
            animator.SetBool("jump", true);
        }



        }

    }
    */






}

