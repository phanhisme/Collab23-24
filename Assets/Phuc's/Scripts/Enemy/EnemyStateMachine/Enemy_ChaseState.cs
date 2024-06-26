using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

public class Enemy_ChaseState : EnemyStates
{
    private Transform _playerTransform;
    private float _chaseMoveSpeed = 3f;
    public Enemy_ChaseState(Enemy enemy, EnemyStateMachineBase enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

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
        Vector2 moveDir = (_playerTransform.position - enemy.transform.position).normalized;
        enemy.MoveEnemy(moveDir *_chaseMoveSpeed);

        //TODO: Change to attack state if the player is in striking distance
        if (enemy._isWithinStrikingDistance)
        {
            enemy._stateMachineBase.ChangeState(enemy._enemyAttackState);
        }
        //TODO: Change to idle if the player out of aggro range
        else if (!enemy._isAggroed)
        {
            enemy._stateMachineBase.ChangeState(enemy._enemyIdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
   
}
