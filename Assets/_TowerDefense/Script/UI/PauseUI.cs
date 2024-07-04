using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace V.TowerDefense
{
    public class PauseUI : MonoBehaviour
    {
        public event Action OnPauseEvent;
        public event Action OnResumeEvent;
        public event Action OnExitEvent;

        [SerializeField] private Button _pauseBTN;
        [SerializeField] private Button _resumeBTN;
        [SerializeField] private Button _exitBTN;
        

        private void Awake() 
        {
            gameObject.SetActive(true);

            AddListenerToEvent(_pauseBTN, OnPauseEvent);
            AddListenerToEvent(_exitBTN, OnExitEvent);
            AddListenerToEvent(_resumeBTN, OnResumeEvent);
        }

        private void Start() 
        {
            // gameObject.SetActive(false);    
            _pauseBTN.onClick.AddListener(() =>
            {
                OnPauseEvent?.Invoke();
            });
        }

        private void AddListenerToEvent(Button button, Action @event)
        {
            button.onClick.AddListener(() =>
            {
                @event?.Invoke();
            });
        }
    }
}
