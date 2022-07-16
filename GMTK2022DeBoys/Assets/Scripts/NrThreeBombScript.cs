using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NrThreeBombScript : MonoBehaviour
{
    public GameObject bombPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha3) == true)
        {
            PlaceBomb();
        }
    }

    void PlaceBomb()
    {
        Vector3 t = transform.position;
        t += Vector3.zero * 2f;
        GameObject bomb = Instantiate(bombPrefab, t, transform.rotation);
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
    }
}
