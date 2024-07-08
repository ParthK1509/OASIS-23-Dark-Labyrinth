using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(0,200)] public int startHealth = 100, currentHealth;

    public static bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0 && !isDead)
        {
            isDead = true;
        }


    }
    
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }
}
