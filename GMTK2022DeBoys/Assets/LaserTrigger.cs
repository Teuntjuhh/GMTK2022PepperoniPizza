using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    public GameObject doorObject;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = doorObject.GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        animator.SetTrigger("TriggerHit");
    }

}
