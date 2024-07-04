using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                GameEventManager.I.GameStateEvent.ChangeState(EGameState.Resume);
                _pauseUI.gameObject.SetActive(false);
            }
            else
            {
                GameEventManager.I.GameStateEvent.ChangeState(EGameState.Pause);
                _pauseUI.gameObject.SetActive(true);                
            }
        }

        private void OnResume()
        {
            _pauseUI.gameObject.SetActive(false);
            GameEventManager.I.GameStateEvent.ChangeState(EGameState.Resume);            
        }

        private void OnExit()
        {
            Loader.LoadScene(EScene.STD_MainMenu);
        }

    }
}
