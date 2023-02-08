using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRB : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float groundDistance = 0.2f;
    public LayerMask Ground;

    private Rigidbody rb;
    private Vector3 inputs = Vector3.zero;
    private bool isGrounded = true;
    private Transform groundChecker;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundChecker = transform.GetChild(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, Ground, QueryTriggerInteraction.Ignore);

        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");

        if(inputs != Vector3.zero)
        {
            transform.forward = inputs;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
        
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputs * speed * Time.fixedDeltaTime);
    }
}
