using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerWeaponHolder : MonoBehaviour
{
    public SpriteRenderer characterRenderer, weaponRenderer;
    //public float weaponDamage;
    public Animator animator;
    public float delay = 0.3f;
    public float attackSpeedBoost = 0.2f;
    private bool attackBlocked;
    public Vector2 PointerPosition { get; set; }
    public bool isAttacking { get; private set; }
    public Transform circle;
    public float radius;
    //public PlayerHealth health;
    PlayerPointer player;
    [SerializeField] public float playerDamage = 1;
    [SerializeField] private Animator attackAnimSpeed;
    [SerializeField] private AnimationEvent animEvent;
    [SerializeField] private LayerMask enemyMask;
    public bool canInstaKill;
    Invisibility invisibility;
    EnemyHealth enemyHealth;
    Frostbite frostbite;
    Lifesteal _lifeSteal;
    
    public void ResetAttack()
    {
        isAttacking = false;
    }
    private void Start()
    {
        player = FindObjectOfType<PlayerPointer>();
        animEvent.OnEventTriggered += ResetAttack;
        animEvent.OnEventTriggered += DetectCol;
        invisibility = FindObjectOfType<Invisibility>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
        frostbite = FindObjectOfType<Frostbite>();
        _lifeSteal = FindObjectOfType<Lifesteal>();

    }

    public void Update()
    {
        checkForInvis();
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

    public void Attack()
    {
        if (attackBlocked)
        {
            return;
        }

        animator.SetTrigger("Attack");

        attackBlocked = true;
        isAttacking = true;

        StartCoroutine(DelayAttack());
        //Debug.Log("attack");

        if (player.boostAttackSpeed == true)
        {
            StartCoroutine(BoostingAttack());
            //Debug.Log("start boosting");
        }
        else
        {
            player.DeActivateTitanGlove();
        }


    }
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 position = circle == null ? Vector3.zero : circle.position;
        Gizmos.DrawWireSphere(position, radius);
    }
    public void DetectCol()
    {
        foreach (Collider2D col in Physics2D.OverlapCircleAll(circle.position, radius, enemyMask))
        {
            col.GetComponent<EnemyHealth>().TestHit(playerDamage, transform.parent.gameObject);
            //Debug.Log(col.name);
            frostbite.checkForFrostChance();
            if (canInstaKill == true && invisibility.activateDuration > 0)
            {
                afterKill();
                Destroy(col.gameObject);
            }
            
            //The player restores 1hp after hitting the enemy
            //Please take my branch
            _lifeSteal.LifestealAfterHit();
        }
    }
    private IEnumerator BoostingAttack()
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
        invisibility.isActivated = false;
        invisibility.ResetInvis();
    }

   
}