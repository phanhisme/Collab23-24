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
    public bool isHit;

    private void Start()
    {
        player = FindObjectOfType<PlayerPointer>();
        playerHealth = FindObjectOfType<PlayerHealth>();
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
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            StartCoroutine(IsHit());
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
        //checkHasShield();
    }
    public IEnumerator IsHit()
    {
        isHit = true;
        float isHitDuration = 0;
        yield return new WaitForSeconds(isHitDuration);
        isHit = false;
    }
}