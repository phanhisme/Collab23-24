using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour, IEnemyMovable, ITriggerCheckable
{
    public Rigidbody2D rb2d { get; set; }
    public bool IsFacingRight { get; set; } = true;
    
    public bool _isAggroed { get; set; }
    
    public bool _isWithinStrikingDistance { get; set; }
    
    #region State Machine Variables
    public EnemyStateMachineBase _stateMachineBase { get; set; }
    public Enemy_IdleState _enemyIdleState { get; set; }
    public Enemy_AttackState _enemyAttackState { get; set; }
    public Enemy_ChaseState _enemyChaseState { get; set; }
    
    #endregion
    
    #region Idle/Random Patrol State Variables

    public float randomMovementRange = 5f;
    public float randomMoveSpeed = 3f;
    public float wanderingTimerReset = 4f;
    
    #endregion

    public GameObject questionMark, exclamationMark;
    
    private void Awake()
    {
        //TODO: Creating new instances of the scripts
        _stateMachineBase = new EnemyStateMachineBase();
        _enemyIdleState = new Enemy_IdleState(this, _stateMachineBase);
        _enemyChaseState = new Enemy_ChaseState(this, _stateMachineBase);
        _enemyAttackState = new Enemy_AttackState(this, _stateMachineBase);

    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        //Start with the idle state
        _stateMachineBase.StateInit(_enemyIdleState);

    }

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        if(IsFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
        if(IsFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }

    public void MoveEnemy(Vector2 velocity)
    {
        rb2d.velocity = velocity;
        CheckForLeftOrRightFacing(velocity);
    }
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        //TODO: Trigger an animation when needed
        _stateMachineBase.currentState.AnimationTriggerEvent(triggerType);
    }

    private void Update()
    {
        _stateMachineBase.currentState.FrameUpdate();
        
        Debug.Log(_stateMachineBase.currentState);
        
        #region Indicator Checks
        if (_stateMachineBase.currentState == _enemyIdleState)
        {
            questionMark.SetActive(true);
            exclamationMark.SetActive(false);
        }
        else if (_stateMachineBase.currentState == _enemyChaseState)
        {
            exclamationMark.SetActive(true);
            questionMark.SetActive(false);
        }
        else
        {
            questionMark.SetActive(false);
            exclamationMark.SetActive(false);
        }
        #endregion
    }

    private void FixedUpdate()
    {
        _stateMachineBase.currentState.PhysicsUpdate();
    }

  
    public enum AnimationTriggerType
    { EnemyDamaged, PlayFootstepsAudio}

  #region Distance Checks
    public void SetAggroStatus(bool isAggroed)
    {
        _isAggroed = isAggroed;
        
    }

    public void SetStrikingDistanceBool(bool isWithinStrikingDistance)
    {
        _isWithinStrikingDistance = isWithinStrikingDistance;
    }
    #endregion
}
