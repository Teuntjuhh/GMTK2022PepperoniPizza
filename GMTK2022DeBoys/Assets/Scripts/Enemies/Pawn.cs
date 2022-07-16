using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour, Enemy
{
    [SerializeField]
    private Player player;
    private PathFinder pathFinder;

    private int contactDamage = 10;

    private float moveDelay = 1;
    private float moveDuration = 0.25f;
    private float hitDelay = 0.1f;

    private int HP = 10;
    private float timeSinceLastMove = 0;
    private float timeSinceLastHit = 0;

    public void ReceiveDamage(int damage)
    {
        if(timeSinceLastHit < hitDelay)
        {
            return;
        }
        timeSinceLastHit = 0;

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

    private void Start()
    {
        pathFinder = GetComponent<PathFinder>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Player>())
        {
            player.ReceiveDamage(contactDamage);
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
        Destroy(gameObject);
        yield return null;
    }

    private void Update()
    {
        timeSinceLastHit += Time.deltaTime;
        timeSinceLastMove += Time.deltaTime;

        if(timeSinceLastMove >= moveDelay)
        {
            Direction? nextDirection = pathFinder.NextTile(player.transform.position);
            if(nextDirection != null)
            {
                StartCoroutine(MoveAnimation(nextDirection));
            }
            timeSinceLastMove = 0;
        }
    }

    private IEnumerator MoveAnimation(Direction? direction)
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
