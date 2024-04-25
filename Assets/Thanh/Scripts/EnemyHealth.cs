using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public float currentHealth, maxHealth;
    public float collideDamage;
    PlayerPointer player;
    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;
    [SerializeField] private bool isDead = false;
    [SerializeField] PlayerHealth playerHealth;


    //BLEEDING EFFECT
    CursedBlade _cursedBladeScript;
    [SerializeField] private float enemyReceiveDMG;
    [SerializeField] private float extraBleedDMG;
    [SerializeField] private int bleedTimer = 3;
    private float HPthreshold;
    private void Start()
    {
        player = FindObjectOfType<PlayerPointer>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        _cursedBladeScript = FindObjectOfType<CursedBlade>();
    }
    public void InitializeHealth(float healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }
    public void TestHit(float damage, GameObject sender)
    {
        if (isDead)
        {
            return;
        }
        if (!player.shielded)
        {
            //Enemy receive dmg
            currentHealth -= damage;
            
        }
        else if(!player.shielded && _cursedBladeScript.isCursedBladeActive)
        {
            
        }
        

    }
    public void ColDamage()
    {
        if (!player.shielded)
        {
            playerHealth.currentHealth -= collideDamage;
            playerHealth.StartCoroutine(playerHealth.IsPlayerHurt());
        }
        else if (player.shielded)
        {
            playerHealth.shieldHealth--;
        }
    }
    public void Dead()
    {
        HPthreshold = maxHealth * 0.15f;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        //When the cursed blade is active and the enemy's health is below 15%, kill.
        else if(_cursedBladeScript.isCursedBladeActive && currentHealth < HPthreshold)
        {
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        Dead();
        Debug.Log(this.currentHealth);
        
    }


    //BLEED FUNCTIONS
    void BleedEffect()
    {
        extraBleedDMG = maxHealth * 0.05f;
    }

   

}