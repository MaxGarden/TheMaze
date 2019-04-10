using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            
    public int currentHealth;                                 
    public Slider healthSlider;                               

    bool isDead;                                               
    bool damaged;                                              


    void Awake()
    {
        currentHealth = startingHealth;
        //enable movment etc of player
    }


    void Update()
    {

    }


    public void TakeDamage(int amount)
    {
  
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;
        
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        //disable movment etc of player
        
    }
}