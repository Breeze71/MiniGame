using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class PauseUIPresneter : MonoBehaviour
    {
        [SerializeField] private PauseUI _pauseUI;


        private void OnEnable() 
        {
            _pauseUI.OnPauseEvent += OnPause;
            _pauseUI.OnResumeEvent += OnResume;
            _pauseUI.OnExitEvent += OnExit;
        }

        private void OnDisable() 
        {
            _pauseUI.OnPauseEvent -= OnPause;
            _pauseUI.OnResumeEvent -= OnResume;
            _pauseUI.OnExitEvent -= OnExit;
        }

        private void OnPause()
        {
            if(_pauseUI.gameObject.activeSelf)
            {
                _pauseUI.gameObject.SetActive(false);
            }
            else
            {
                _pauseUI.gameObject.SetActive(true);                
            }
        }

        private void OnResume()
        {
            
        }

        private void OnExit()
        {
            
        }

    }
}
