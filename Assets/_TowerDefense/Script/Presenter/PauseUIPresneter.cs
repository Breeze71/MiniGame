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
            _pauseUI.OnPauseEvent += PauseUI_OnPause;
        }

        private void OnDisable() 
        {
            _pauseUI.OnPauseEvent -= PauseUI_OnPause;
        }

        private void PauseUI_OnPause()
        {
            Debug.Log("press pause");
            if(_pauseUI.gameObject.activeSelf)
            {
                _pauseUI.gameObject.SetActive(false);
            }
            else
            {
                _pauseUI.gameObject.SetActive(true);                
            }
        }
    }
}
