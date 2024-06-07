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
        animEvent.OnAttackPerformed += Enter;
    }

    public void Enter()
    {
        animator.SetTrigger("attack");
        animator.SetInteger("counter", CurrentAttackCounter);
        //attackCounterResetTimer.StopTimer();
        OnEnter?.Invoke();
    }

    public void Exit()
    {
        CurrentAttackCounter++;
        //animator.SetBool("active", false);
        //attackCounterResetTimer.StartTimer();
        OnExit?.Invoke();
    }

    private void OnEnable()
    {
        animEvent.OnEventTriggered += Exit;
        animEvent.OnAttackPerformed -= Enter;
    }

    private void OnDisable()
    {
        animEvent.OnEventTriggered -= Exit;
    }
}
