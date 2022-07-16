using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookObject : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public bool hasCollided;
    public BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        hasCollided = false;
        boxCollider = this.GetComponent<BoxCollider>();
        player = GameObject.FindWithTag("Player");
        StartCoroutine(StartLife(5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasCollided)
        {
            transform.position += Time.deltaTime * speed * transform.forward;
        }

    }
    private IEnumerator SmoothLerp(float time, Vector3 target)
    {
        Vector3 startingPos = player.transform.position;
        Vector3 finalPos = target;

        float elapsedTime = 0;
    
        while (elapsedTime < time)
        {
            player.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    Vector3 getHookPosition(Vector3 targetPosition)
    {
        if(player.transform.position.x != targetPosition.x)
        {
            if(player.transform.position.x > targetPosition.x)
            {
                return new Vector3(targetPosition.x + 1, 0.5f, targetPosition.z);
            }
            else
            {
                return new Vector3(targetPosition.x - 1, 0.5f, targetPosition.z);
            }
        }
        else if(player.transform.position.z != targetPosition.z)
        {
            if(player.transform.position.z > targetPosition.z)
            {
                return new Vector3(targetPosition.x, 0.5f, targetPosition.z + 1);
            }
            else
            {
                return new Vector3(targetPosition.x, 0.5f, targetPosition.z - 1);
            }
        }
        return player.transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        hasCollided = true;
        boxCollider.isTrigger = true;
        Debug.Log(getHookPosition(collision.gameObject.transform.position));

        StartCoroutine(SmoothLerp(.5f, getHookPosition(collision.gameObject.transform.position)));
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player"){
            Debug.Log("Destroyed");
            Destroy(this.gameObject);
        }
    }
    IEnumerator StartLife(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }

}
