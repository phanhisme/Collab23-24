using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDagger : WeaponBase
{
    
    public override void Attack()
    {
        base.Attack();
        if (attackBlocked)
        {
            return;
        }
        attackBlocked = true;
        isAttacking = true;
        animator.SetTrigger("attack");
        StartCoroutine(DelayAttack());
    }

    public override void SpecialAttack()
    {
        base.SpecialAttack();
        if (specialAttackBlock)
            return;
        specialAttackBlock = true;
        isAttacking = true;
        StartCoroutine(DelaySpecialAttack());
        animator.SetTrigger("special");
        
    }

    public IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
        //Debug.Log("running delay");
    }

    public IEnumerator DelaySpecialAttack()
    {
        yield return new WaitForSeconds(specialAttackCD);
        specialAttackBlock = false;
    }
}
