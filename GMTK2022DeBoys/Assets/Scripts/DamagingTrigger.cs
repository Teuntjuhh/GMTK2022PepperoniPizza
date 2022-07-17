using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingTrigger : MonoBehaviour
{
    public bool isShielded;
    public Shield shieldScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        { 
            shieldScript = other.gameObject.GetComponentInChildren<Shield>();
            if(!shieldScript.isShielded)
            {
                DamagePlayer(other.gameObject);
            } 
        }
    }

    void DamagePlayer(GameObject player)
    {
        player.GetComponent<Health>().TakeDamage();
    }
}
