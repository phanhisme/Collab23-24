using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public delegate void OnAnimationEventTriggered();
    public OnAnimationEventTriggered OnEventTriggered, OnAttackPerformed;

    public void TriggerEvent()
    {
        OnEventTriggered?.Invoke();
    }
    public void TriggerAttack()
    {
        OnAttackPerformed?.Invoke();
    }
}
