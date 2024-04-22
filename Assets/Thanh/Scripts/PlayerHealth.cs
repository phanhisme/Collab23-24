using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;
    public float currentHealth, maxHealth;
    //public int collideDamage;
    PlayerPointer player;
    [SerializeField]
    private bool isDead = false;
    public float shieldHealth = 2;
    public float shieldTimer = 2;
    public bool isHurt;
    

    private void Start()
    {
        player = FindObjectOfType<PlayerPointer>();
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
        if (sender.layer == gameObject.layer)
        {
            return;
        }
        if (!player.shielded)
        {
            currentHealth -= damage;
            //isHurt = true;
            StartCoroutine(IsPlayerHurt());
        }
        else if (player.shielded)
        {
            shieldHealth--;
        }
    }
    //public void ColDamage()
    //{
    //    if (!player.shielded)
    //    {
    //        currentHealth -= collideDamage;
    //    }
    //    else if (player.shielded)
    //    {
    //        shieldHealth--;
    //    }
    //}
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
        checkHasShield();
    }
    IEnumerator HealShield()
    {
        yield return new WaitForSeconds(8);
        player.ActivateShield();
        shieldHealth = 2;
        shieldTimer = 2;
    }
    public void Timer()
    {
        if (shieldTimer > 0)
        {
            shieldTimer -= Time.deltaTime; // run the countdown
        }
        else if (shieldTimer <= 0)
        {          
            shieldTimer = 0;
        }
        if (shieldTimer == 0)
        {           
            shieldTimer = 2;
            shieldHealth -= 1;
            Debug.Log(shieldHealth);
        }
        if (shieldHealth <= 0)
        {
            player.DeActivateShield();
            StartCoroutine(HealShield());
        }
        int minutes = Mathf.FloorToInt(shieldTimer / 60);
        int seconds = Mathf.FloorToInt(shieldTimer % 60);
    }
    public void checkHasShield()
    {
        if (gameObject.tag == "Player")
        {          
            if (player.HasShield())
            {
                Timer();
            }
        }
    }
    public IEnumerator IsPlayerHurt()
    {
        isHurt = true;
        float playerIsHurtingTime = 2;
        yield return new WaitForSeconds(playerIsHurtingTime);
        isHurt = false;
    }

}