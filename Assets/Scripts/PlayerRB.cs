using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRB : MonoBehaviour
{
    public float speed = 7f;
    public float jumpHeight = 2f;
    public float groundDistance = 0.05f;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public LayerMask Ground;

    private Rigidbody rb;
    private Vector3 inputs = Vector3.zero;
    private bool isGrounded = true;
    private Transform groundChecker;

    Animator animator;
    
    private bool isWalking;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       jump = new Vector3(0.0f, 3.5f, 0.0f);
        //groundChecker = transform.GetChild(0);
        isWalking = false;
        isJumping = false;
        animator = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, Ground, QueryTriggerInteraction.Ignore);

        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Vertical");
        inputs.z = Input.GetAxis("Horizontal");
         
        if(inputs != Vector3.zero)
        {
            if(isJumping)
            {
                animator.SetBool("walking", false);
            }
            else { animator.SetBool("walking", true); }

            transform.forward = inputs;
            




        }
        else
        {
            animator.SetBool("walking", false);
        }



        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("walking", false);
            
           animator.SetBool("jump", true);
            isJumping = true;
        }


    }

    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + inputs * speed * Time.fixedDeltaTime);



    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            isJumping = false;
            animator.SetBool("jump", false);
            

        }
    }

    private void OnTriggerStay(Collider trigger)
    {
        if(trigger.gameObject.tag == "BoatCollider")
        {
            
            
                Vector3 boatPos = new Vector3(trigger.transform.position.x + 1f, trigger.transform.position.y + 30f, trigger.transform.position.z - 30f);
            rb.position = boatPos;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.position = boatPos + new Vector3(55f, 0, 0);
                animator.SetBool("jump", true);
            }
            
            
        }
    }

   

}
