using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    public int currentHealth, maxHealth;
    public int collideDamage;
    private bool delayShieldDamage;
    Player player;
    //public int damage;
    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;
    public float shieldTimer = 2;
    private bool startTime;
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
            //delayShieldDamage = false;
            //StartCoroutine(Timer());
        }
        checkHasShield();
        if (player.shieldHealth <= 0) 
        {
            player.DeActivateShield();
            StartCoroutine(HealShield());
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
        //Debug.Log(shieldTimer);
        //Timer();
    }
    IEnumerator HealShield()
    {
        yield return new WaitForSeconds(8);
        player.ActivateShield();
    }

    public void Timer()
    {
        if(shieldTimer > 0)
        {
            shieldTimer -= Time.deltaTime;
            Debug.Log("a");
            
        }
        if (shieldTimer < 0)
        {
            player.shieldHealth--;
            startTime = false;
            Debug.Log(player.shieldHealth);
            Debug.Log(shieldTimer);
            shieldTimer = 2;
        }
        int minutes = Mathf.FloorToInt(shieldTimer / 60);
        int seconds = Mathf.FloorToInt(shieldTimer % 60);
        if(startTime == false)
        {
            checkHasShield();
        }
    }
    public void checkHasShield()
    {
        if (player.HasShield())
        {
            startTime = true;
            if (startTime == true)
            {
                Timer();
            }
        }
    }
}