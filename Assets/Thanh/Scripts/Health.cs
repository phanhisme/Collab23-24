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
    //private bool delayShieldDamage;
    Player player;
    //public int damage;
    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;
    public float shieldTimer = 2;
    private bool startTime;
    //WeaponHolder weaponHolder;
    //public GameObject sender;

    private void Start()
    {
        player = GetComponent<Player>();
        //weaponHolder = GetComponent<WeaponHolder>();
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
        checkHasShield();
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
        if (startTime == true)
        {
            Timer();
        }
    }
    IEnumerator HealShield()
    {
        yield return new WaitForSeconds(8);
        player.ActivateShield();
        player.shieldHealth = 2;
    }
    public void Timer()
    {
        if(shieldTimer > 0)
        {
            shieldTimer -= Time.deltaTime; // run the countdown
        }
        if (shieldTimer < 0)
        {
            player.shieldHealth--;
            startTime = false;
            Debug.Log(player.shieldHealth);
            shieldTimer = 2;
        }
        if (player.shieldHealth <= 0)
        {
            player.DeActivateShield();
            StartCoroutine(HealShield());
        }
        int minutes = Mathf.FloorToInt(shieldTimer / 60);
        int seconds = Mathf.FloorToInt(shieldTimer % 60);
    }
    public void checkHasShield()
    {
        if (player.HasShield())
        {
            startTime = true;
        }
    }

}