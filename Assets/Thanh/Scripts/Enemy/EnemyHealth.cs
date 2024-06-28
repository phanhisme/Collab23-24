using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField]
    
    public float collideDamage;
   
    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;
    [SerializeField] private bool isDead = false;
    //[SerializeField] PlayerHealth playerHealth;
    public bool isHit;

    PlayerPointer player;
    CursedBlade _cursedBladeScript;

    [SerializeField] public float maxHealth { get; set; } = 100f;
    public float currentHealth { get; set; }

    private void Start()
    {
        player = FindObjectOfType<PlayerPointer>();
        //playerHealth = FindObjectOfType<PlayerHealth>();
        _cursedBladeScript = FindObjectOfType<CursedBlade>();


        currentHealth = maxHealth;
    }
    
    public IEnumerator IsHit()
    {
        if(_cursedBladeScript.isCursedBladeActive)
        {
            //Start bleeding when the enemy is hit
            StartCoroutine(BleedEnemy());
        }
        isHit = true;
        float isHitDuration = 0;
        yield return new WaitForSeconds(isHitDuration);
        isHit = false;
    }
    
    // ---- BLEED FUNCTIONS ---- 
    //Please use Phuc's pushed code for thisssssssssss
    IEnumerator BleedEnemy()
    {
        //Invoke the function right away for 6 seconds, the enemy will bleed every 1 sec
        InvokeRepeating(nameof(Bleed), 0f, 1f);
        yield return new WaitForSeconds(_cursedBladeScript.bleedTimer);
        CancelInvoke();
    }
    void Bleed()
    {
        currentHealth -= _cursedBladeScript.extraBleedDMG;
    }

    public void Damage(float damage, GameObject sender)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //When the cursed blade is active and the enemy's health is below 15%, kill.
        if (_cursedBladeScript.isCursedBladeActive && currentHealth < _cursedBladeScript.HpThreshold)
        {
            Destroy(gameObject);
        }
        //If the cursed blade is not active then check this statement
        else if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}