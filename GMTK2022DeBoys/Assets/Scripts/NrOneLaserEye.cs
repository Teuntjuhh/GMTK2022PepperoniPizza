using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NrOneLaserEye : MonoBehaviour
{
    private LineRenderer laserRenderer;
    [SerializeField]
    private Transform startPoint;

    private void Start()
    {
        laserRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //startPoint is point 0 
        laserRenderer.SetPosition(0, startPoint.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit)) //-transform.right currently determines the direction of the laser, so change that when cube movement changes
        {
            if(hit.collider)
            {
                //end point is point 1
                laserRenderer.SetPosition(1, hit.point);
            }
            if(hit.transform.tag == "Enemy")
            {
                Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            //in case the laser never hits anything, stop it at around 5000 ish distance
            laserRenderer.SetPosition(1, Vector3.forward * 5000);
        }
    }
}
