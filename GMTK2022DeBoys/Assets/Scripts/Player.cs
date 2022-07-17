using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int HP = 100;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void ReceiveDamage(int damage, Vector3 knockBack)
    {
        rigidbody.AddForce(knockBack, ForceMode.Impulse);
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
        yield return null;
    }

}
