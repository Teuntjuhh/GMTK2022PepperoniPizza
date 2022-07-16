using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NrOneLaserEye : MonoBehaviour
{
    private LineRenderer laserRenderer;
    [SerializeField]
    private Transform startPoint;

    private int LaserDamge = 1;

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
        //Debug.Log(transform.eulerAngles.y);


        if (Physics.Raycast(transform.position, transform.forward, out hit)) //transform.forward determines the direction of the laser
        {
            if(hit.collider)
            {
                //end point is point 1
                laserRenderer.SetPosition(1, hit.point);
            }

            Enemy hitEnemy = hit.transform.GetComponent<Enemy>();

            if(hitEnemy != null)
            {
                hitEnemy.ReceiveDamage(LaserDamge);
            }
        }
        else
        {
            //in case the laser never hits anything, stop it at around 5000 ish distance
            laserRenderer.SetPosition(1, transform.forward * 5000);
        }
    }
}
