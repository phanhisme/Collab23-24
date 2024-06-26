using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHammer : WeaponBase
{
    float delaydamage = 1;
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

    public override void ChargeAttack()
    {
        base.ChargeAttack();
        if (specialAttackBlock)
            return;
        specialAttackBlock = true;
        isAttacking = true;
        StartCoroutine(DelaySpecialAttack());
        power += maxAttackPower;
        animator.SetTrigger("charge");
    }

    public override void ReleaseCharge()
    {
        base.ReleaseCharge();
        animator.SetTrigger("release");
        StartCoroutine(DELAY());
    }

    IEnumerator DELAY()
    {
        yield return new WaitForSeconds(delaydamage);
        power -= maxAttackPower;
    }

    IEnumerator DelayAttack()
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
