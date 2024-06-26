using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class Enemy_AttackState : EnemyStates
{

    public Enemy_AttackState(Enemy enemy, EnemyStateMachineBase enemyStateMachine) : base(enemy, enemyStateMachine)
    {
       
        
    }
    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (!enemy._isWithinStrikingDistance && enemy._isAggroed)
        {
            enemy._stateMachineBase.ChangeState(enemy._enemyChaseState);
        }
        else if (!enemy._isWithinStrikingDistance && !enemy._isAggroed)
        {
            enemy._stateMachineBase.ChangeState(enemy._enemyIdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
    }
    

   

 

   
}
