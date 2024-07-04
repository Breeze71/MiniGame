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

            AddListenerToEvent(_pauseBTN, () => OnPauseEvent?.Invoke());
            AddListenerToEvent(_exitBTN, () => OnExitEvent?.Invoke());
            AddListenerToEvent(_resumeBTN, () => OnResumeEvent?.Invoke());
        }
        
        // Action 實際上是引用
        private void AddListenerToEvent(Button button, Action eventAction)
        {
            if(button == null)  return;
            button.onClick.AddListener(() =>
            {
                // 實際這裡是調用 () => lambda 裡的 func
                eventAction?.Invoke();
            });
        }
    }
}
