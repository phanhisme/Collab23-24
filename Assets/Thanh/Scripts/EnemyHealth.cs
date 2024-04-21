using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;
    public float currentHealth, maxHealth;
    public float collideDamage;
    PlayerPointer player;
    [SerializeField] private PlayerHealth playerHealth;
    private bool isDead = false;
    //public float shieldHealth = 2;
    //public float shieldTimer = 2;

    

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
        if (sender.layer == gameObject.layer)
        {
            return;
        }
        if (!player.shielded)
        {
            currentHealth -= damage;
        }
        else if (player.shielded)
        {
            playerHealth.shieldHealth--;
        }
    }
    public void ColDamage()
    {
        if (!player.shielded)
        {
            playerHealth.currentHealth -= collideDamage;
        }
        else if (player.shielded)
        {
            playerHealth.shieldHealth--;
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
    //IEnumerator HealShield()
    //{
    //    yield return new WaitForSeconds(8);
    //    player.ActivateShield();
    //    shieldHealth = 2;
    //    shieldTimer = 2;
    //}
    //public void Timer()
    //{
    //    if (shieldTimer > 0)
    //    {
    //        shieldTimer -= Time.deltaTime; // run the countdown
    //    }
    //    else if (shieldTimer <= 0)
    //    {          
    //        shieldTimer = 0;
    //    }
    //    if (shieldTimer == 0)
    //    {           
    //        shieldTimer = 2;
    //        shieldHealth -= 1;
    //        Debug.Log(shieldHealth);
    //    }
    //    if (shieldHealth <= 0)
    //    {
    //        player.DeActivateShield();
    //        StartCoroutine(HealShield());
    //    }
    //    int minutes = Mathf.FloorToInt(shieldTimer / 60);
    //    int seconds = Mathf.FloorToInt(shieldTimer % 60);
    //}
    //public void checkHasShield()
    //{
    //    if (gameObject.tag == "Player")
    //    {          
    //        if (player.HasShield())
    //        {
    //            Timer();
    //        }
    //    }
    //}
}