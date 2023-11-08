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
    Player player;
    //public int damage;
    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;
    //public GameObject sender;

    private void Start()
    {
        player = GetComponent<Player>();
    }
    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    public void TestHit(int damage, GameObject sender)
    {
        if (isDead)
        {
            return;
        }
        if (sender.layer == gameObject.layer)
        {
            return;
        }
        if (!player.shielded)
        {
            currentHealth -= damage;
        }
        if (player.HasShield())
        {
            player.shieldHealth--;
            
        }
        if(player.shieldHealth <= 0) 
        {
            player.DeActivateShield();
        }
    }
    public void ColDamage()
    {
        if(!player.shielded)
        {
            currentHealth -= collideDamage;
        }
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
}