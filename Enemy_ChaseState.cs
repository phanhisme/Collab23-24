using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ChaseState : EnemyStates
{
    public Enemy_ChaseState(Enemy enemy, EnemyStateMachineBase enemyStateMachine) : base(enemy, enemyStateMachine)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}