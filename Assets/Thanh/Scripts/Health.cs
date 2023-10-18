using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int currentHealth, maxHealth;
    //public int damage;
    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    //private bool isDead = false;

    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        //isDead = false;
    }

    public void TestHit(int damage)
    {
        currentHealth -= damage;
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

    //public void Hit(int amount, GameObject sender)
    //{
    //    currentHealth = currentHealth - amount;
    //    if (isDead)
    //        return;
    //    if (sender.layer == gameObject.layer)
    //        return;



    //    if (currentHealth > 0)
    //    {
    //        OnHitWithReference?.Invoke(sender);

    //    }
    //    else
    //    {
    //        OnDeathWithReference?.Invoke(sender);
    //        isDead = true;
    //        Destroy(gameObject);
    //    }
    //}
}