using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public GameObject orientation;
    public Vector3 inputDirection;
    public float rotationSpeed;
    public float gravityScale;

    public float horizontalInput;
    public float verticalInput;
    public float inputTimeH;
    public float inputTimeV;

    public bool isMoving;
    public bool isGrounded;
    public bool isBoosting;
    public bool isGrappling;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        isGrounded = (Physics.Raycast(transform.position, Vector3.down, .55f));
        
        InputListener();
        TimeFactor();
       
        if (!isMoving && isGrounded && !isBoosting && !isGrappling && inputDirection != Vector3.zero)
        {
            Move(inputDirection);
        }
    }
    void FixedUpdate()
    {
        if(!isGrappling)
        {
            Gravity();
        }
    }

    void Move(Vector3 direction)
    {
        var anchor = transform.position + (Vector3.down + direction) * 0.5f;
        var axis = Vector3.Cross(Vector3.up, direction);
        StartCoroutine(DiceRoll(anchor, axis));
    }

    IEnumerator DiceRoll(Vector3 anchor, Vector3 axis)
    {
        isMoving = true;

        for(int i=0; i<(90/rotationSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rotationSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = new Vector3(Mathf.Round(transform.position.x), 0.5f, Mathf.Round(transform.position.z));
        isMoving = false;
    }
    
    Vector3 GetInputDirection()
    {
        if(horizontalInput != 0 && verticalInput != 0)
        {
            if(inputTimeH > inputTimeV)
            {
                return inputDirection = new Vector3(horizontalInput, 0, 0);
            }
            else
            {
                return inputDirection = new Vector3(0, 0, verticalInput);
            }
        }
        else
        {
            return inputDirection = new Vector3(horizontalInput, 0, verticalInput);
        }
    }

    void Gravity()
    {
        if(!isGrounded && !isMoving && !isBoosting)
        {
            rigidbody.AddForce(-orientation.transform.up * gravityScale, ForceMode.Force);
        }
        else
        {
            if(!isBoosting)
            {
                rigidbody.velocity = Vector3.zero;
            }
        }
    }

    void InputListener()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        GetInputDirection();
    }

    void TimeFactor()
    {
        if(horizontalInput != 0)
        {
            inputTimeH += Time.deltaTime;
        }
        else
        {
            inputTimeH = 0;
        }

        if(verticalInput != 0)
        {
            inputTimeV += Time.deltaTime;
        }
        else
        {
            inputTimeV = 0;
        }
    }
}
