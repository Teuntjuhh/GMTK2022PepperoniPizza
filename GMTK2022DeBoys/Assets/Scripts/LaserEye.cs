using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEye : MonoBehaviour
{
    public int reflections;
    public float maxLength;

    private LineRenderer laserRenderer;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;

    private void Awake()
    {
        laserRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            laserRenderer.enabled = !laserRenderer.enabled;
        }
        if (laserRenderer.enabled)
        {
            ShootLaser();
        }

    }

    void ShootLaser()
    {
        ray = new Ray(transform.position, transform.forward);

        laserRenderer.positionCount = 1;
        laserRenderer.SetPosition(0, transform.position);
        float remainingLength = maxLength;

        for (int i = 0; i < reflections; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
            {
                laserRenderer.positionCount += 1;
                laserRenderer.SetPosition(laserRenderer.positionCount - 1, hit.point);
                remainingLength -= Vector3.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                if (hit.collider.tag != "Mirror")
                {
                    break;
                }
            }
            else
            {
                laserRenderer.positionCount += 1;
                laserRenderer.SetPosition(laserRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
            }
        }
    }

}
