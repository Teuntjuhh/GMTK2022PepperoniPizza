using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NrOneLaserEye : MonoBehaviour
{
    int maxBounces = 5;
    private LineRenderer laserRenderer;
    [SerializeField]
    private Transform startPoint;

    private int LaserDamage = 1;

    private void Start()
    {
        laserRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //startPoint is point 0 
        laserRenderer.SetPosition(0, startPoint.position);
        

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            laserRenderer.enabled = !laserRenderer.enabled;
        }
        if(laserRenderer.enabled)
        {
            LaserEye();
        }
       
    }
    void LaserEye()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)) //transform.forward determines the direction of the laser
        {
            Vector3 position = transform.position;
            Vector3 direction = transform.forward;

            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<Enemy>().ReceiveDamage(LaserDamage);
            }
            if (hit.transform.tag == "Mirror")
            {
                laserRenderer.SetPosition(1, hit.point);
                position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                Ray ray = new Ray(position, direction);
                laserRenderer.SetPosition(2, hit.point);
            }
            
            
            if (hit.collider)
            {
                //end point is point 1
                laserRenderer.SetPosition(1, hit.point);
            }
        }
        else
        {
            //in case the laser never hits anything, stop it at around 5000 ish distance
            laserRenderer.SetPosition(1, transform.forward * 5000);
        }
    }
}
