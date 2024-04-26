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
    [SerializeField] private float HpThreshold;
    private void Start()
    {
        player = FindObjectOfType<PlayerPointer>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        _cursedBladeScript = FindObjectOfType<CursedBlade>();
        
        //Getting bleed effect
        extraBleedDMG = maxHealth * 0.05f;
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
        if (!player.shielded && !_cursedBladeScript.isCursedBladeActive)
        {
            //Enemy receive dmg
            currentHealth -= damage;
            
        }
        else if(!player.shielded && _cursedBladeScript.isCursedBladeActive)
        {
            currentHealth -= damage;
            StartCoroutine(BleedEffect());
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
        //Execute when the enemy's health is below 15%
        HpThreshold = maxHealth * 0.15f;
        
        //When the cursed blade is active and the enemy's health is below 15%, kill.
        if(_cursedBladeScript.isCursedBladeActive && currentHealth < HpThreshold)
        {
            Destroy(gameObject);
        }
        //If the cursed blade is not active then check this statement
        else if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        Dead();
        Debug.Log(this.currentHealth);
    }

    IEnumerator BleedEffect()
    {
        do
        { 
            currentHealth -= extraBleedDMG; 
            yield return new WaitForSeconds(bleedTimer);
            
        } while (_cursedBladeScript.isCursedBladeActive);
    }
    


   
      
    

   

}