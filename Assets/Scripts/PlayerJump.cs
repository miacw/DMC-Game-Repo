using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    Rigidbody rb;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 6.0f, 0.0f);
        animator = GetComponent<Animator>();
        
    }

    private void OnCollisionStay()
    {
        isGrounded = true;
        //animator.SetBool("jump", false);

        
    }


    private void FixedUpdate()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
          if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("walking", false);
            //animator.SetBool("jump", true);
        }
        
    }
}
