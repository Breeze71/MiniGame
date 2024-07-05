using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace V.TowerDefense
{
    public class EndGameUI : MonoBehaviour
    {
        public event Action OnResumeEvent;
        public event Action OnExitEvent;


        [SerializeField] private Image _winIMG;
        [SerializeField] private Image _lossIMG;
        [SerializeField] private Button _replayBTN;
        [SerializeField] private Button _exitBTN;
        

        private void Awake() 
        {
            gameObject.SetActive(true);

            AddListenerToEvent(_replayBTN, () => OnResumeEvent?.Invoke());
            AddListenerToEvent(_exitBTN, () => OnExitEvent?.Invoke());

             _replayBTN.onClick.AddListener(() =>
             {
                Loader.ReLoadScene();
             });

             _exitBTN.onClick.AddListener(() =>
             {
                Loader.LoadScene(EScene.STD_MainMenu);
             });
        }

        private void OnEnable() 
        {
            GameEventManager.I.GameEvent.OnPlayerInhibitorDestroyEvent += OnPlayerInhibitorDestroyEvent;
            GameEventManager.I.GameEvent.OnEnemyInhibitorDestroyEvent += OnEnemyInhibitorDestroyEvent;
        }

        private void OnEnemyInhibitorDestroyEvent()
        {
            GameEventManager.I.GameStateEvent.ChangeState(EGameState.Pause);
            gameObject.SetActive(true);
            _lossIMG.gameObject.SetActive(false);
        }

        private void OnPlayerInhibitorDestroyEvent()
        {
            GameEventManager.I.GameStateEvent.ChangeState(EGameState.Pause);
            gameObject.SetActive(true);
            _winIMG.gameObject.SetActive(false);
        }

        private void Start() 
        {
            gameObject.SetActive(false);
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
