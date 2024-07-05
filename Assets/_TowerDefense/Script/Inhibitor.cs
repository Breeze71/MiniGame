using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace V.TowerDefense
{
    public class Inhibitor : MonoBehaviour, IDamagable
    {
        [SerializeField] private EMoveDirection _eMoveDirection;
        
        [SerializeField] private int _healthMax;
        public HealthSystem HealthSystem {get; set;}

        private void Awake() 
        {
            HealthSystem = new HealthSystem(_healthMax);    
        }

        private void OnEnable() 
        {
            HealthSystem.HealthChangedEvent += OnHealthChange;
        }

        private void OnDisable() 
        {
            HealthSystem.HealthChangedEvent += OnHealthChange;                
        }

        private void OnHealthChange()
        {
            if(HealthSystem.GetHealthAmount() <= 0)
            {
                if(_eMoveDirection == EMoveDirection.Left)
                {
                    GameEventManager.I.GameEvent.OnEnemyInhibitorDestryoy();
                }
                else if(_eMoveDirection == EMoveDirection.Right)
                {
                    GameEventManager.I.GameEvent.OnPlayerInhibitorDestroy();                    
                }
            }
        }

        public void TakeDamage(int amount)
        {
            HealthSystem.TakeDamage(amount);
        }

        [Button]
        public void TestTakeDamage()
        {
            HealthSystem.TakeDamage(1000);
        }
    }
}
