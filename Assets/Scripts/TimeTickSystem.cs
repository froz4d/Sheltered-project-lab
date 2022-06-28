using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
public class TimeTickSystem : MonoBehaviour
{

    public class OnTickEventArgs : EventArgs
    {
        public int tick;
    }
    
    public static event EventHandler<OnTickEventArgs> OnTick;
    
    private const float TICK_TIMER_MAX = .2f;

    private int tick;
    private float tickTimer;

    private void Awake()
    {
        tick = 0;
    }

    private void Update()
    {
        tickTimer += Time.deltaTime;
        if (tickTimer >= TICK_TIMER_MAX)
        {
            tickTimer -= TICK_TIMER_MAX;
            tick++;
            if (OnTick != null) OnTick(this, new OnTickEventArgs { tick = tick });
            //CMDebug.TextPopupMouse("tick: " + tick);
        }
    }
}
