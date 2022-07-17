using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shieldObject;
    public float shieldDuration;
    public bool isShielded;
    // Start is called before the first frame update
    void Start()
    {
        isShielded = false;
        shieldObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha4))
        {
            StartCoroutine(SetShield());
        }
        
        if(shieldObject.activeSelf)
        {
            GroundShielded();
        }
        else
        {
            isShielded = false;
        }
    }

    void GroundShielded()
    {
        if(shieldObject.transform.position.y < 0.45f)
        {
            isShielded = true;
        }
        else
        {
            isShielded = false;
        }
    }

    IEnumerator SetShield()
    {
        shieldObject.SetActive(true);
        yield return new WaitForSeconds(shieldDuration);
        shieldObject.SetActive(false);
    }
}
