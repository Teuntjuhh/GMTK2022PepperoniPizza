using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int health;
    public Text text;
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
        text.text = health.ToString();
        if(health >= 0)
        {
            Death();
        }
    }
    public void TakeDamage()
    {
        health--;
    }

    public void Death()
    {

    }
}
