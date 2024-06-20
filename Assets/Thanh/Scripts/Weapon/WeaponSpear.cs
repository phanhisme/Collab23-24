using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WeaponSpear : WeaponBase
{
    public override void Attack()
    {
        base.Attack();
        //animator.SetTrigger("attack");
    }
}
