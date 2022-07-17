using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class PathFinder : MonoBehaviour
{
    private int activationRange = 20;

    public Direction? NextTile(Vector3 targetPosition)
    {
        List<Direction> directionsToGo = new List<Direction>();

        if ((Mathf.Round(transform.position.z) > Mathf.Round(targetPosition.z)))
        {
            directionsToGo.Add(Direction.Down);
        }

        else if ((Mathf.Round(transform.position.z) < Mathf.Round(targetPosition.z)))
        {
            directionsToGo.Add(Direction.Up);
        }

        if ((Mathf.Round(transform.position.x) > Mathf.Round(targetPosition.x)))
        {
            directionsToGo.Add(Direction.Left);
        }

        else if ((Mathf.Round(transform.position.x) < Mathf.Round(targetPosition.x)))
        {
            directionsToGo.Add(Direction.Right);
        }

        if (directionsToGo.Count > 0 && Vector3.Distance(transform.position, targetPosition) < activationRange)
        {
            return directionsToGo[Random.Range(0, directionsToGo.Count)];
        }

        return null;
    }
}
