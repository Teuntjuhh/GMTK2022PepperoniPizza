using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int health;
    public GameObject[] diceHealth = new GameObject[6]; 
    // Start is called before the first frame update
    void Start()
    {
        health = 6;
    }

    // Update is called once per frame
    void Update()
    {
        ManageLife();
    }

    public void ManageLife()
    {
        if(health >= 0)
        {
            Death();
        }
    }
    public void TakeDamage()
    {
        health--;
        diceHealth[health].SetActive(false);
    }

    public void Death()
    {

    }
}
