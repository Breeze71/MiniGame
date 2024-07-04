using System;
using UnityEngine;
using V.Utilities;

public class LoaderCallback : MonoBehaviour
{
    [SerializeField] private float delayTime = 3f;
    private bool isFirstUpdate = true;

    private Timer timer;

    private void Awake() 
    {
        timer = new Timer(delayTime);
    }

    private void OnEnable() 
    {
        timer.OnTimerDone += OnTimerDone;
    }

    private void OnTimerDone()
    {
        Loader.LoaderCallback();
    }

    private void Update() 
    {
        timer.Tick();

        if(isFirstUpdate)
        {
            isFirstUpdate = false;

            timer.StartTimer();
        }    
    }
}
