using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public SpriteRenderer characterRenderer, weaponRenderer;
    private bool attackHit = false;
    //public float weaponDamage;
    public Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;
    public Vector2 PointerPosition {  get; set; }
    public bool isAttacking { get; private set; }
    public Transform circle;
    public float radius;

    public Health health;
    PlayerPointer player;


    [SerializeField] public float playerDamage = 1;
    [SerializeField] private Animator attackAnimSpeed;

    public void ResetAttack()
    {
        isAttacking = false;
    }
    private void Start()
    {
       player = FindObjectOfType<PlayerPointer>();
    }

    public void Update()
    {
        if (isAttacking)
        {
            return;
        }
        Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
        transform.right = direction;
        Vector2 scale = transform.localScale;
        if(direction.x < 0)
        {
            scale.y = -1;
        }
        else if(direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;
        
        if(transform.localEulerAngles.z > 180 && transform.localEulerAngles.z <360)
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
        if(attackBlocked)
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
        foreach(Collider2D col in Physics2D.OverlapCircleAll(circle.position, radius))
        {
            col.GetComponent<Health>().TestHit(playerDamage, transform.parent.gameObject);
            //Debug.Log(col.name);

        }
    }
    private IEnumerator BoostingAttack()
    {
        //Debug.Log("boosting");
        delay = 0.1f;
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
}
