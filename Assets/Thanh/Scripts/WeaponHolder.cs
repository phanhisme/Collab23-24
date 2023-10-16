using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public SpriteRenderer characterRenderer, weaponRenderer;
    public Enemy enemy;
    private bool attackHit = false;
    public float weaponDamage;
    public Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;
    public Vector2 PointerPosition {  get; set; }
    public bool isAttacking { get; private set; }
    public void ResetAttack()
    {
        isAttacking = false;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            attackHit = true;
        }
        if(attackHit == true)
        {
            enemy = collision.gameObject.GetComponent<Enemy>();
            //enemy.TakeDamage();
        }
    }

    public void Attack()
    {
        if(attackBlocked)
        {
            return;
        }
        //OnCollisionEnter2D();
        //enemy.TakeDamage(damage);
        animator.SetTrigger("Attack");
        attackBlocked = true;
        isAttacking = true;
        StartCoroutine(DelayAttack());
    }
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
