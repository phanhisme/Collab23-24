using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D.Animation;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;
    public float currentHealth, maxHealth;
    public float collideDamage;
    PlayerPointer player;
    [SerializeField]
    private bool isDead = false;
    public float shieldHealth = 2;
    public float shieldTimer = 2;
    public bool isHurt;
    WeaponBase weaponBase;
    EnemyWeaponHolder enemyWeaponHolder;
    private float atkSpeedMultiplier = 0.1f;
    float baseAtkSpeed = 0.3f;
    public bool haveShield;
    Heartsteel heartsteel;

    private Animator anim;

    private SpriteRenderer sr;

 
    private void Start()
    {
        player = FindObjectOfType<PlayerPointer>();
        weaponBase = FindObjectOfType<WeaponBase>();
        heartsteel = FindObjectOfType<Heartsteel>();
        enemyWeaponHolder = FindObjectOfType<EnemyWeaponHolder>();

        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
      
       
      
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
        if(heartsteel.hasHeartSteel == true && currentHealth > 0)
        {
            heartsteel.shieldHeart--;
            heartsteel.DeactivateHeartsteel();
            currentHealth += enemyWeaponHolder.enemyDamage;
            OnHitWithReference?.Invoke(sender);
        }
        if (!player.shielded && currentHealth > 0)
        {
            currentHealth -= damage;
            //isHurt = true;
            StartCoroutine(IsPlayerHurt());
            OnHitWithReference?.Invoke(sender);
        }
        else if (player.shielded)
        {
            shieldHealth--;
        }
        if (currentHealth <= 0)
        {
            
            isDead = true;
            OnDeathWithReference?.Invoke(gameObject);
           
        }
    }
    public void ColDamage()
    {
        if (!player.shielded && currentHealth > 0)
        {
            currentHealth -= collideDamage;
            StartCoroutine(IsPlayerHurt());
        }
        else if (player.shielded)
        {
            shieldHealth--;
        }
    }
    public void Dead()
    {
        StartCoroutine(TriggerDeadAnim());
    }
    public void Update()
    {
        Dead();
        anim.SetFloat("isOutofHealth", currentHealth);
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
            shieldHealth -= 2;
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
                checkIfShieldActive();
            }
        }
    }
    public IEnumerator IsPlayerHurt()
    {
        isHurt = true;
        if (isHurt)
        {
            anim.SetTrigger("isDamaged");
            AudioManagerScript.Instance.PlaySoundEffect("Hit_SFX");
            
           
        }
        
        
        float playerIsHurtingTime = 0;
        yield return new WaitForSeconds(playerIsHurtingTime);
        isHurt = false;
        sr.color = new Color(255, 255, 255);    //return back to the original sprite renderer color
    }

    //GuardianBlessing
    public void boostAtkSpeed()
    {
        if (player.shielded == true && haveShield == true)
        {
            weaponBase.delay = weaponBase.delay * atkSpeedMultiplier;
        }
        if(!player.shielded == true && haveShield == true)
        {
            weaponBase.delay = baseAtkSpeed;
        }
    }

    public void checkIfShieldActive()
    {
        if (player.gbActive == true)
        {
            haveShield = true;
        }
        boostAtkSpeed();
    }

    IEnumerator TriggerDeadAnim()
    {
        if (currentHealth <= 0)
        {
            anim.SetFloat("isOutOfHealth", currentHealth);
            yield return new WaitForSeconds(.5f);
            Destroy(gameObject);

        }

    }
   
    
}