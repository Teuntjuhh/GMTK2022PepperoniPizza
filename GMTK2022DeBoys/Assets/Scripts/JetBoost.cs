using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetBoost : MonoBehaviour
{
    public Movement movementScript;
    public Rigidbody rigidbody;
    public float boostAmount;
    public float maxBoostHeight;
    // Start is called before the first frame update
    void Start()
    {
        movementScript = this.GetComponentInParent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Alpha6))
        {
            if(rigidbody.transform.position.y < maxBoostHeight)
            {
                movementScript.isBoosting = true;
                rigidbody.AddForce(this.transform.forward * boostAmount, ForceMode.Force);
            }
            else if(rigidbody.transform.position.y >= maxBoostHeight)
            {
                rigidbody.velocity = Vector3.down * 2f;
            }
        }
        else
        {
            movementScript.isBoosting = false;
        }
    }
}

