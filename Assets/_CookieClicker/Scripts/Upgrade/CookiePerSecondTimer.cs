using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using V.Utilities;

namespace V.CookieClicker
{
    public class CookiePerSecondTimer : MonoBehaviour
    {
        public float TimerDuration = 1f;
        public double CookiePerSecond { get; set;}
        private Timer timer;

        private void Awake() 
        {
            timer = new Timer(TimerDuration);
        }
        
        private void Start() 
        {
            timer.OnTimerDone += Timer_OnTimerDone;

            timer.StartTimer();     
        }

        private void Timer_OnTimerDone()
        {
            CookieManager.Instance.SimpleCookieIncrease(CookiePerSecond);

            timer.StartTimer();

            Debug.Log("TimerDone");
        }

        private void Update() 
        {
            timer.Tick();     
        }
    }
}
