using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDice : MonoBehaviour, Enemy
{
    [SerializeField]
    private Player player;
    private PathFinder pathFinder;

    private float contactDamage = 10;

    private float moveDelay = 1;
    private float rotationSpeed = 3;
    private float hitDelay = 0.1f;

    private int HP = 10;
    private float timeSinceLastMove = 0;
    private float timeSinceLastHit = 0;

    private void Start()
    {
        pathFinder = GetComponent<PathFinder>();
    }

    private void Update()
    {
        timeSinceLastHit += Time.deltaTime;
        timeSinceLastMove += Time.deltaTime;

        if (timeSinceLastMove >= moveDelay)
        {
            Direction? nextDirection = pathFinder.NextTile(player.transform.position);
            if (nextDirection != null)
            {
                Vector3 axisDirection = Vector3.zero;

                switch(nextDirection)
                {
                    case Direction.Up:
                        axisDirection = new Vector3(0, 0, 1);
                        break;
                    case Direction.Down:
                        axisDirection = new Vector3(0, 0, -1);
                        break;
                    case Direction.Left:
                        axisDirection = new Vector3(-1, 0, 0);
                        break;
                    case Direction.Right:
                        axisDirection = new Vector3(1, 0, 0);
                        break;
                    default:
                        break;
                }

                var anchor = transform.position + (Vector3.down + axisDirection) * 0.5f;
                var axis = Vector3.Cross(Vector3.up, axisDirection);


                StartCoroutine(DiceRoll(anchor, axis));
            }
            timeSinceLastMove = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            player.ReceiveDamage(contactDamage);
        }
    }

    private IEnumerator DiceRoll(Vector3 anchor, Vector3 axis)
    {
        /*float rotationDuration = 1;
        float currentDuration = 0;

        while ( currentDuration < rotationDuration)
        {
            currentDuration += Time.deltaTime;
            transform.RotateAround(anchor, axis, Time.deltaTime / 90 * rotationDuration);
            yield return null;
        }
        transform.position = new Vector3(Mathf.Round(transform.position.x), 0.5f, Mathf.Round(transform.position.z));*/

        for (int i = 0; i < (90 / rotationSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rotationSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = new Vector3(Mathf.Round(transform.position.x), 0.5f, Mathf.Round(transform.position.z));
    }

    public void ReceiveDamage(int damage)
    {
        if (timeSinceLastHit < hitDelay)
        {
            return;
        }
        timeSinceLastHit = 0;

        HP -= damage;
        if (HP > 0)
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
        Destroy(gameObject);
        yield return null;
    }

}
