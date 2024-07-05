using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class GameEvent
    {
        public event Action OnPlayerInhibitorDestroyEvent;
        public event Action OnEnemyInhibitorDestroyEvent;

        public void OnPlayerInhibitorDestroy()
        {
            OnPlayerInhibitorDestroyEvent?.Invoke();
        }

        public void OnEnemyInhibitorDestryoy()
        {
            OnEnemyInhibitorDestroyEvent?.Invoke();
        }
    }
}
