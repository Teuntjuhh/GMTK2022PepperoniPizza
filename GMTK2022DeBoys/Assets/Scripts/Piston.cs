using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    public GameObject pistonWall;
    public Rigidbody rigidbody;
    public float amount;
    public bool isToggling;
    public bool isToggled;
    // Start is called before the first frame update
    void Start()
    {
        isToggled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            if(!isToggling)
            {
                StartCoroutine(TogglePiston());
            }
        }
    }

    IEnumerator TogglePiston()
    {
        isToggling = true;
        for(int i=0; i<5; i++){
            if(!isToggled){
                pistonWall.transform.position += transform.forward * amount;
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                pistonWall.transform.position -= transform.forward * amount;
                yield return new WaitForSeconds(0.01f);
            } 
        }
        if(isToggled)
        {
            isToggled = false;
        }
        else
        {
            isToggled = true;
        }
        isToggling = false;
    }
}
