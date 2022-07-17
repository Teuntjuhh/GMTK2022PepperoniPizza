using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    public GameObject doorObject;
    public GameObject triggerHolder;
    Animator triggerAnimator;
    Animator objectAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(triggerHolder.name);
        triggerAnimator = triggerHolder.transform.root.GetComponent<Animator>();
        objectAnimator = doorObject.GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        triggerAnimator.SetTrigger("TriggerHit");
        objectAnimator.SetTrigger("TriggerHit");
    }

}
