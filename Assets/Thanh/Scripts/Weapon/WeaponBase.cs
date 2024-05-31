using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    //animation
    //pattern
    //overlap
    //public WeaponDataSO weaponData;
    public float range;
    public float power;
    public float affectedSpeed;
    public float weight;
    public float delay;
    public bool attackBlocked;
    public float attackSpeedBoost;
    public bool isAttacking { get; private set; }
    public bool canInstaKill;
    //public float playerDamage;

    public Animator animator;
    public SpriteRenderer characterRenderer, weaponRenderer;
    public Vector2 PointerPosition { get; set; }
    public Transform circle;
    public AnimationEvent animEvent;
    public Animator attackAnimSpeed;
    public LayerMask enemyMask;

    //EnemyHealth enemyHealth;
    Invisibility invisibility;
    Frostbite frostbite;
    PlayerPointer player;
    public virtual void Attack()
    {
        if (attackBlocked)
        {
            return;
        }
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

    protected void ResetAttack()
    {
        isAttacking = false;
    }

    public void DetectCol()
    {
        foreach (Collider2D col in Physics2D.OverlapCircleAll(circle.position, range, enemyMask))
        {
            col.GetComponent<EnemyHealth>().TestHit(power, transform.parent.gameObject);
            Debug.Log(col.name);
            frostbite.checkForFrostChance();
            if (canInstaKill == true && invisibility.activateDuration > 0)
            {
                afterKill();
                Destroy(col.gameObject);
            }
        }
    }

    protected IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

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

    public void UpdateData()
    {

    }

    public void Start()
    {
        player = FindObjectOfType<PlayerPointer>();
        animEvent.OnEventTriggered += ResetAttack;
        animEvent.OnEventTriggered += DetectCol;
        invisibility = FindObjectOfType<Invisibility>();
        //enemyHealth = FindObjectOfType<EnemyHealth>();
        frostbite = FindObjectOfType<Frostbite>();
        //range = weaponData.range;
    }

    public void Update()
    {
        checkForInvis();
        PointAtCursor();
    }
}
