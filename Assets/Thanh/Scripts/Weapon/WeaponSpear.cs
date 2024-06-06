using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WeaponSpear : WeaponBase
{
    public event Action OnEnter, OnExit;

    public override void Attack()
    {
        base.Attack();
        base.Enter();
    }
}
