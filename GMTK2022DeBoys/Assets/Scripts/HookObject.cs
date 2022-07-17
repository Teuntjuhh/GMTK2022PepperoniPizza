using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookObject : MonoBehaviour
{
    public GameObject player;
    public Movement movementScript;
    public float speed;
    public bool hasCollided;
    public BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        hasCollided = false;
        boxCollider = this.GetComponent<BoxCollider>();
        player = GameObject.FindWithTag("Player");
        movementScript = player.GetComponent<Movement>();
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
    private IEnumerator SmoothLerp(GameObject targetObject, float time, Vector3 target)
    {
        movementScript.isGrappling = true;
        Vector3 startingPos = targetObject.transform.position;
        Vector3 finalPos = target;

        float elapsedTime = 0;
    
        while (elapsedTime < time)
        {
            targetObject.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        movementScript.isGrappling = false;
    }

    Vector3 GetHookPosition(Vector3 startPosition,Vector3 targetPosition)
    {
        if(Mathf.Abs(startPosition.x + -targetPosition.x) > Mathf.Abs(startPosition.z + -targetPosition.z))
        {
            if(startPosition.x > targetPosition.x)
            {
                return new Vector3(targetPosition.x + 1, targetPosition.y, targetPosition.z);
            }
            else
            {
                return new Vector3(targetPosition.x - 1, targetPosition.y, targetPosition.z);
            }
        }
        else if(Mathf.Abs(startPosition.z + -targetPosition.z)>1f);
        {
            if(startPosition.z > targetPosition.z)
            {
                return new Vector3(targetPosition.x, targetPosition.y, targetPosition.z + 1);
            }
            else
            {
                return new Vector3(targetPosition.x, targetPosition.y, targetPosition.z - 1);
            }
        }
        return startPosition;
    }
    void OnCollisionEnter(Collision collision)
    {
        hasCollided = true;
        boxCollider.isTrigger = true;
        this.transform.parent = collision.gameObject.transform;
        if(collision.gameObject.tag == "Interactable")
        {
            StartCoroutine(SmoothLerp(collision.gameObject ,.5f, GetHookPosition(collision.gameObject.transform.position, player.transform.position)));
        }
        else
        {
            StartCoroutine(SmoothLerp(player ,.5f, GetHookPosition(player.transform.position, collision.gameObject.transform.position)));
        }
    }

    IEnumerator StartLife(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }

}
