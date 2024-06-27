using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using System;

public class WeaponBase : MonoBehaviour
{
    //animation
    //pattern
    //overlap
    //public WeaponDataSO weaponData;

    public static WeaponBase instance;

    //Stats and variables
    public float range;
    public float power;
    public float affectedSpeed;
    public float weight;
    public float delay;
    public bool attackBlocked;
    public float attackSpeedBoost;
    public bool isAttacking { get; set; }
    public bool canInstaKill;
    //public float playerDamage;

    //Components
    public Animator animator;
    public SpriteRenderer characterRenderer, weaponRenderer;
    public Vector2 PointerPosition { get; set; }
    public Transform circle;
    public AnimationEvent animEvent;
    public Animator attackAnimSpeed;
    public LayerMask enemyMask;
    WeaponActivation weaponActivation;

    //Hammer
    float currentChargeTime = 0f;
    float maxChargeTime = 3f;
    float minChargeTime = 1f;
    public float maxAttackPower = 10f;
    public bool isCharging;
    //bool canAttack;

    //Dagger
    public float specialAttackCD;
    public bool isSpecialAttacking;
    public bool specialAttackBlock;


    //Scripts
    //EnemyHealth enemyHealth;
    Invisibility invisibility;
    Frostbite frostbite;
    PlayerPointer player;
    protected Timer attackCounterResetTimer;
    public virtual void Attack()
    {
        if (player.boostAttackSpeed == true)
        {
            StartCoroutine(BoostingAttack());
        }
        else
        {
            player.DeActivateTitanGlove();
        }
    }

    public virtual void ChargeAttack()
    {
        if (Input.GetMouseButtonDown(1) && isAttacking)
        {
            StartCharging();

        }
        if (Input.GetMouseButtonUp(1) && isCharging)
        {
            ReleaseCharge();

        }
    }

    public void StartCharging()
    {
        currentChargeTime = 0;
        isCharging = true;
        Charge();
    }

    public void Charge()
    {
        //Debug.Log("a");
        currentChargeTime += Time.deltaTime;
        if (currentChargeTime > maxChargeTime)
        {
            currentChargeTime = maxChargeTime;
        }
    }

    public virtual void ReleaseCharge()
    {
        isCharging = false;
        if (currentChargeTime == maxChargeTime)
        {

            Attack();
            Debug.Log(power);
        }
        if (currentChargeTime >= minChargeTime)
        {
            Attack();
            Debug.Log(power);
        }
        else
        {
            Debug.Log("not enough charge time");
            //animator.SetTrigger("idle");
        }
        currentChargeTime = 0f;
    }

    public virtual void SpecialAttack()
    {
        range += 0.02f;
    }

    protected void ResetAttack()
    {
        isAttacking = false;
    }

    public void DetectCol()
    {
        foreach (Collider2D col in Physics2D.OverlapCircleAll(circle.position, range, enemyMask))
        {
            col.GetComponent<EnemyHealth>().Damage(power, transform.parent.gameObject);
            //Debug.Log(col.name);
            frostbite.checkForFrostChance();
            if (canInstaKill == true && invisibility.activateDuration > 0)
            {
                afterKill();
                Destroy(col.gameObject);
            }
        }
    }

    

    //public IEnumerator DelayDelay()
    //{
    //    yield return new WaitForSeconds(delay);
    //    Debug.Log("running delay");
    //}

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 position = circle == null ? Vector3.zero : circle.position;
        Gizmos.DrawWireSphere(position, range);
    }

    protected IEnumerator BoostingAttack()
    {
        //Debug.Log("boosting");
        delay = delay * attackSpeedBoost;
        yield return new WaitForSeconds(10f);
        delay = 0.3f;
        player.boostAttackSpeed = false;
        if (player.boostAttackSpeed == true)
        {
            attackAnimSpeed.speed = 2;
        }
        else
        {
            attackAnimSpeed.speed = 1;
        }
    }

    #region StealthKill
    //StealthKill
    public void checkForInvis()
    {
        if (invisibility.isActivated == true && player.skActive == true)
        {
            canInstaKill = true;
        }
        if (canInstaKill == true && invisibility.activateDuration <= 0)
        {
            afterKill();
        }
    }
    public void afterKill()
    {
        Debug.Log("after");
        invisibility.isActivated = false;
        invisibility.activateDuration = 0;
        invisibility.ResetInvis();
    }
    #endregion
    protected void PointAtCursor()
    {
        if (isAttacking)
        {
            return;
        }
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;
        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;

        if (transform.localEulerAngles.z > 180 && transform.localEulerAngles.z < 360)
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        }
    }

    public void Start()
    {
        instance = this;
        animator = GetComponentInChildren<Animator>();
        player = FindObjectOfType<PlayerPointer>();
        animEvent.OnEventTriggered += ResetAttack;
        animEvent.OnEventTriggered += DetectCol;
        invisibility = FindObjectOfType<Invisibility>();
        frostbite = FindObjectOfType<Frostbite>();
        //enemyHealth = FindObjectOfType<EnemyHealth>();
        //range = weaponData.range;
        //StartCoroutine(MyCoroutine());
    }

    public void Update()
    {
        checkForInvis();
        PointAtCursor();
        //Debug.Log(currentChargeTime);
    }

    IEnumerator MyCoroutine()
    {
        Debug.Log("Coroutine started");

        // Wait for 2 seconds
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
        specialAttackBlock = false;
        Debug.Log( delay + "have passed");

        // Additional code to execute after the wait
        // Ensure this code is being reached
        Debug.Log("Coroutine ended");
    }
}

