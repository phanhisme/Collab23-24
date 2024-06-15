using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDagger : WeaponBase
{
    
    public override void Attack()
    {
        base.Attack();
        animator.SetTrigger("attack");
    }

    public override void SpecialAttack()
    {
        base.SpecialAttack();
        animator.SetTrigger("special");
    }
}
