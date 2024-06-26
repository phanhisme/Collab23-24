using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer 
{
    private float startTime;
    private float duration;
    private float targetTimer;
    private bool isActive;
    public event Action OnTimerDone;

    public Timer(float duration)
    {
        this.duration = duration;
    }

    public void StartTimer()
    {
        startTime = Time.time;
        targetTimer = startTime + duration;
        isActive = true;
    }
    
    public void StopTimer()
    {
        isActive = false;
    }

    public void Tick()
    {
        if (!isActive) return;
        if(Time.time >= targetTimer)
        {
            OnTimerDone?.Invoke();
            StopTimer();
        }
    }
}
