using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetBoost : MonoBehaviour
{
    public Movement movementScript;
    public Rigidbody rigidbody;
    public float boostAmount;
    public float maxBoostHeight;
    public float fuel;
    public float fuelBurnAmount;
    public float fuelRecoveryRate;
    public bool isBoosting;
    public bool overHeating;
    // Start is called before the first frame update
    void Start()
    {
        fuel = 100;
        movementScript = this.GetComponentInParent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        BurnFuel();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Alpha3))
        {
            if(rigidbody.transform.position.y < maxBoostHeight && !overHeating)
            {
                isBoosting = true;
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
            isBoosting = false;
            movementScript.isBoosting = false;
        }
    }
    IEnumerator Overheat()
    {
        while(fuel < 50f)
        {
            overHeating = true;
            yield return null;
        }
        overHeating = false;
    }
    void BurnFuel()
    {
        if(isBoosting && fuel > 0 && !overHeating)
        {
            fuel -= Time.deltaTime * fuelBurnAmount;
        }
        else
        {
            StartCoroutine(Overheat());
            if(fuel < 100)
            {
                fuel += Time.deltaTime * fuelRecoveryRate;
            }
            else
            {
                fuel = 100;
            }
            
        }
        
    }
}