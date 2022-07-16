using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetBoost : MonoBehaviour
{
    public Movement movementScript;
    public Rigidbody rigidbody;
    public float boostAmount;
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
        if(Input.GetKey(KeyCode.Alpha5))
        {
            movementScript.isBoosting = true;
            rigidbody.AddForce(this.transform.forward * boostAmount, ForceMode.Force);
        }
        else
        {
            movementScript.isBoosting = false;
        }
    }
}

