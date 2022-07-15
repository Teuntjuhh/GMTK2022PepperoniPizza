using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class Pawn : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private float moveDelay = 1;
    private float moveDuration = 0.25f;

    private int HP = 10;
    private float timeSinceLastMove = 0;

    public void ReceiveDamage(int damage)
    {
        HP -= damage;
        if(HP > 0)
        {
            StartCoroutine(DamageAnimation());
        }    
        else
        {
            StartCoroutine(DeathAnimation());
        }
    }

    private IEnumerator DamageAnimation()
    {
        //TODO
        yield return null;
    }

    private IEnumerator DeathAnimation()
    {
        //TODO
        yield return null;
    }

    private void Update()
    {
        timeSinceLastMove += Time.deltaTime;

        if(timeSinceLastMove >= moveDelay)
        {
            MoveTile();
            timeSinceLastMove = 0;
        }
    }

    private void MoveTile()
    {
        List<Direction> directionsToGo = new List<Direction>();

        if((Mathf.Round(transform.position.z) > Mathf.Round(player.transform.position.z)))
        {
            directionsToGo.Add(Direction.Down);
        }

        else if ((Mathf.Round(transform.position.z) < Mathf.Round(player.transform.position.z)))
        {
            directionsToGo.Add(Direction.Up);
        }

        if ((Mathf.Round(transform.position.x) > Mathf.Round(player.transform.position.x)))
        {
            directionsToGo.Add(Direction.Left);
        }

        else if ((Mathf.Round(transform.position.x) < Mathf.Round(player.transform.position.x)))
        {
            directionsToGo.Add(Direction.Right);
        }

        if(directionsToGo.Count > 0)
        {
            StartCoroutine(MoveAnimation(directionsToGo[Random.Range(0, directionsToGo.Count)]));
        }
    }

    private IEnumerator MoveAnimation(Direction direction)
    {
        Vector3 targetPosition = new Vector3();

        switch (direction)
        {
            case Direction.Up:
                targetPosition = transform.position + new Vector3(0, 0, 1);
                break;
            case Direction.Down:
                targetPosition = transform.position + new Vector3(0, 0, -1);
                break;
            case Direction.Left:
                targetPosition = transform.position + new Vector3(-1, 0, 0);
                break;
            case Direction.Right:
                targetPosition = transform.position + new Vector3(1, 0, 0);
                break;
            default:
                break;
        }

        float currentDuration = 0;
        Vector3 startingPosition = transform.position;

        while (currentDuration < moveDuration)
        {
            currentDuration += Time.deltaTime;
            transform.position = Vector3.Slerp(startingPosition, targetPosition, currentDuration / moveDuration);
            yield return null;
        }
    }

    private void DamagePlayer()
    {
        //TODO
    }
}
