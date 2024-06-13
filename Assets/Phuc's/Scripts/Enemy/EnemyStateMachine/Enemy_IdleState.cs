using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
using UnityEngine;

public class Enemy_IdleState : EnemyStates
{
    private Vector3 _targetPos;
    private Vector3 _direction;
    
    Vector2 originPos;
    private float circleWidth;
    public Enemy_IdleState(Enemy enemy, EnemyStateMachineBase enemyStateMachine) : base(enemy, enemyStateMachine)
    {
       

    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        _targetPos = GetRandomPointInCircle();
        originPos = Vector2.zero;

    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        //Debug.Log(enemy._stateMachineBase.currentState);
      
        _direction = (_targetPos - enemy.transform.position).normalized;
        enemy.MoveEnemy(_direction * enemy.randomMoveSpeed);
        enemy.wanderingTimerReset -= 1 * Time.deltaTime;
        
        //TODO: If the enemy reaches the point OR the wandering timer ends the enemy will find a new point and reset the timer back to 4
        if ((enemy.transform.position - _targetPos).sqrMagnitude < 0.01 || enemy.wanderingTimerReset <= 0)
        {
            _targetPos = GetRandomPointInCircle(); //if the enemy reaches the point, find a new point
            enemy.wanderingTimerReset = 3f;
        }
        
        //TODO: If the player steps in aggro area, the enemy starts chasing
        if (enemy._isAggroed)
        {
            enemy._stateMachineBase.ChangeState(enemy._enemyChaseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    //TODO: Well, find a random point in a circle
    private Vector3 GetRandomPointInCircle()
    {
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemy.randomMovementRange;
        
    }
    
}
