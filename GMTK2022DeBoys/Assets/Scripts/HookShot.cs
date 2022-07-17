using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{
    public GameObject hookPrefab;
    public GameObject firePoint;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GameObject hookClone = Instantiate(hookPrefab, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}
