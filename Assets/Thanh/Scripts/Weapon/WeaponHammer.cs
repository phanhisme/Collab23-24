using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHammer : WeaponBase
{
    
    public override void Attack()
    {
        base.Attack();
        animator.SetTrigger("attack");
    }

    public override void ChargeAttack()
    {
        base.ChargeAttack();
        animator.SetTrigger("charge");
    }

    public override void ReleaseCharge()
    {
        base.ReleaseCharge();
        animator.SetTrigger("release");
    }
}
