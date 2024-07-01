using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class HealthPresenter : MonoBehaviour
    {
        [SerializeField] private UnitBase _unit;
        [SerializeField] private HealthBarUI _healthBarUI;

        private void OnEnable() 
        {
            if(_unit.HealthSystem != null)
            {
                _unit.HealthSystem.HealthChangedEvent += Unit_OnHealthChanged;
            }
        }

        private void Start() 
        {
            _unit.HealthSystem.HealthChangedEvent += Unit_OnHealthChanged; 
        }

        private void OnDisable() 
        {
            // _unit.HealthSystem.HealthChangedEvent -= Unit_OnHealthChanged;                
        }

        private void Unit_OnHealthChanged()
        {
            _healthBarUI.SetBarUI(_unit.HealthSystem.GetHealthPercent());
        }
    }
}
