using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace V
{
    public enum InputType
    {
        GamePlay,
        UI,
    }

    public class InputManager : MonoBehaviour, PlayerInput.IGamePlayActions, PlayerInput.IUIActions
    {
        public static InputManager Instance {get; private set;} 
        [SerializeField] private GameObject _mapUI;
        public event Action TapEvent;
        private PlayerInput _playerInput;
        public event Action<Vector2> MoveEvent;
        public event Action JumpEvent;
        public event Action JumpCanceledEvent;

        public event Action PauseEvent;
        public event Action ResumeEvent;

        public event Action SubmitEvent;

        private void Awake() 
        {
            if(Instance != null)
            {
                Debug.LogError("More than one Input Manager");
                return;
            }

            Instance = this;
        }

        private void OnEnable() 
        {
            if(_playerInput == null)
            {
                _playerInput = new PlayerInput();

                _playerInput.GamePlay.SetCallbacks(this);
                _playerInput.UI.SetCallbacks(this);
            }

        }

        private void Start() 
        {    
            SetActionMap(InputType.UI);
        }

        private void SetActionMap(InputType inputType)
        {
            foreach(InputActionMap inputMap in _playerInput.asset.actionMaps)
            {
                if(inputMap.name == inputType.ToString())
                {
                    inputMap.Enable();
                }
                else
                {
                    inputMap.Disable();
                }
            }
        }


        #region GamePlay
        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                JumpEvent?.Invoke();
            }

            if(context.phase == InputActionPhase.Canceled)
            {
                JumpCanceledEvent?.Invoke();
            }
        }


        public void OnPause(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                PauseEvent?.Invoke();

                SetActionMap(InputType.UI);
                Debug.Log("Pause");
            }
        }
        #endregion



        #region UI
        public void OnResume(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                ResumeEvent?.Invoke();

                SetActionMap(InputType.GamePlay);
                Debug.Log("REsume");
            }            
        }

        public void OnSubmit(InputAction.CallbackContext context)
        {
            SubmitEvent?.Invoke();
        }

        public void OnScreenTap(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Performed)
            {
                // Loader.LoadScene(TowerDefense.EScene.STD_1);
                TapEvent?.Invoke();
                _mapUI.SetActive(true);

                SetActionMap(InputType.GamePlay);
            }
        }
        #endregion
    }
}
