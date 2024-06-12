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
        Debug.Log("attack");
        animator.SetBool("active", true);
        animator.SetInteger("counter", CurrentAttackCounter);
        //animEvent.OnAttackPerformed += Enter;
        animEvent.OnEventTriggered += Exit;
    }

    public void Enter()
    {
        //Debug.Log("attack");
        animator.SetBool("active", true);
        
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
        //animEvent.OnEventTriggered += Exit;
        animEvent.OnAttackPerformed += Enter;
    }

    private void OnDisable()
    {
        animEvent.OnEventTriggered += Exit;
    }
}
