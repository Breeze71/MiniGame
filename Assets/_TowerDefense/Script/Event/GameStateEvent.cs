using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class GameStateEvent
    {
        public event Action<EGameState> OnStateChange;

        public EGameState EGameState{get; private set;} = EGameState.None;

        public void ChangeState(EGameState eGameState)
        {
            EGameState = eGameState;
            OnStateChange?.Invoke(EGameState);
        }
    }
}
