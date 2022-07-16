using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;

    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rigidbodyComponent;
    private int superJumpsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            jumpKeyWasPressed = true;
            rigidbodyComponent.AddForce(Vector3.up * 3, ForceMode.VelocityChange);
        }

       
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    //FixedUpdate is called once every physics update
    void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput*2, rigidbodyComponent.velocity.y, 0);
        rigidbodyComponent.velocity = new Vector3(rigidbodyComponent.velocity.x, 0, verticalInput*2);
        // if (!isGrounded)
        // {
        //     return;
        // }

        if (Physics.OverlapSphere(groundCheckTransform.position, 1f, playerMask).Length == 0)
        {
            return;
        }
        Debug.Log("Here!");
        if (jumpKeyWasPressed == true)
        {
            Debug.Log("Pressed jump!");
            float jumpPower = 5f;
            if (superJumpsRemaining > 0)
            {
                
                jumpPower *= 2;
                superJumpsRemaining--;
            }
            rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }
    }



    // The tutorial guy said that this was an alternate method but it doesn't check if the feet are touching the ground

    // private bool isGrounded;

    // private void OnCollisionEnter(Collision collision)
    // {
    //     isGrounded = true;
    // }

    // private void OnCollisionExit(Collision collision)
    // {
    //     isGrounded = false;
    // }
}
