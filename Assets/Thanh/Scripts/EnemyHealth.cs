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
        if (!player.shielded)
        {
            currentHealth -= damage;
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
    //    player.shieldHealth = 2;
    //    shieldTimer = 2;
    //}
    //public void Timer()
    //{
    //    if(shieldTimer > 0)
    //    {
    //        shieldTimer -= Time.deltaTime; // run the countdown
    //    }
    //    else if (shieldTimer <= 0)
    //    {
    //        //Debug.Log(this.gameObject.name);
    //        shieldTimer = 0;  
    //    }
    //    if(shieldTimer == 0)
    //    {
    //        //Debug.Log("asdasd");
    //        shieldTimer = 2;
    //        player.shieldHealth -= 1;
    //        Debug.Log(player.shieldHealth);
    //    }
    //    if (player.shieldHealth <= 0)
    //    {
    //        player.DeActivateShield();
    //        StartCoroutine(HealShield());
    //    }
    //    int minutes = Mathf.FloorToInt(shieldTimer / 60);
    //    int seconds = Mathf.FloorToInt(shieldTimer % 60);
    //}
    //public void checkHasShield()
    //{
    //    if(gameObject.tag == "Player")
    //    {
    //        //Debug.Log("1");
    //        if (player.HasShield())
    //        {
    //            //Debug.Log("2");
    //            Timer();
    //        }
    //    }
    //}

    
}