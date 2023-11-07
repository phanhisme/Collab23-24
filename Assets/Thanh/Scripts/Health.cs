using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int currentHealth, maxHealth;
    public int collideDamage;
    private bool delayDamage;
    //public int damage;
    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;
    public GameObject sender;

    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    public void TestHit(int damage)
    {
        if (isDead)
        {
            return;
        }
        if (sender.layer == gameObject.layer)
        {
            return;
        }

        currentHealth -= damage;

    }
    public void ColDamage()
    {
        currentHealth -= collideDamage;
    }
    public void Dead()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        Dead();
    }

    public void AvoidCol()
    {
        
            
    }
    //public void Hit(int amount, GameObject sender)
    //{
    //    currentHealth = currentHealth - amount;
    //    



    //    
    //}
}