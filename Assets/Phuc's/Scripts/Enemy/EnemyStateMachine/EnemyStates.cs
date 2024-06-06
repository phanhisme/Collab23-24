using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates
{
    protected Enemy enemy;
    protected EnemyStateMachineBase enemyStateMachine;

    public EnemyStates(Enemy enemy, EnemyStateMachineBase enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }

    public virtual void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType) { }


}
