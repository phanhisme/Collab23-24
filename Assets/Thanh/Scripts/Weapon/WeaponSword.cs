using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : WeaponBase
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
        animator.SetTrigger("SwordAttack");
        StartCoroutine(DelayAttack());
    }

    public IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
        //Debug.Log("running delay");
    }
}

