using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destroyedVersion;

    // Update is called once per frame
    public void DestroyDestructible()
    {
        Destroy(gameObject);
    }
}
