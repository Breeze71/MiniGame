using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set;}

    private PlayerInput playerInput;

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }    

        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }

    public Vector2 GetPlayerMoveInput()
    {
        return playerInput.Player.Move.ReadValue<Vector2>().normalized;
    }
    
}
