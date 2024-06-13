using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachineBase 
{
    public EnemyStates currentState { get; set; }
    public void StateInit(EnemyStates startingState)
    {
        currentState = startingState;
        currentState.EnterState();  //Enter a starting state, in this case idle
    }
    public void ChangeState(EnemyStates newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();      //Enter a new state
    }
}
