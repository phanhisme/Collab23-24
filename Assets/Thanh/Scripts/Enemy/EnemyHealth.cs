using System;
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
    [SerializeField] CursedBlade _cursedBladeScript;
    public bool isHit;

    public float HpThreshold;
    private int bleedTimer;
    [Seriprivate float extraBleedDMG;


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
        
        if (currentHealth > 0 && _cursedBladeScript.isCursedBladeActive)
        {
            //currentHealth -= damage;
            StartCoroutine(BleedEffect());
            Debug.Log(currentHealth);
        }
        else if (currentHealth > 0)
        {
            currentHealth -= damage;
            StartCoroutine(IsHit());

        }
    }
    public void Dead()
    {
       
        //Execute when the enemy's health is below 15%
        HpThreshold = maxHealth * 0.15f;

        //When the cursed blade is active and the enemy's health is below 15%, kill.
        if (_cursedBladeScript.isCursedBladeActive && currentHealth < HpThreshold)
        {
            Destroy(gameObject);
        }
        //If the cursed blade is not active then check this statement
        else if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        Dead();
        
    }
    public IEnumerator IsHit()
    {
        isHit = true;
        float isHitDuration = 0;
        yield return new WaitForSeconds(isHitDuration);
        isHit = false;
    }
    IEnumerator BleedEffect()
    {
        extraBleedDMG = maxHealth * 0.05f;
        do
        {
            currentHealth -= extraBleedDMG;
            yield return new WaitForSeconds(bleedTimer);

        } while (_cursedBladeScript.isCursedBladeActive);
    }
}