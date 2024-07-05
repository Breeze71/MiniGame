using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using V.Tool.JuicyFeeling;

namespace V.TowerDefense
{
    public class InhibitorHealthPresenter : MonoBehaviour
    {
        [SerializeField] private Inhibitor _inhibitor;
        [SerializeField] private HealthBarUI _healthBarUI;
        [SerializeField] private SquashAndStretch squashAndStretch;

        private void OnEnable() 
        {
            if(_inhibitor.HealthSystem != null)
            {
                _inhibitor.HealthSystem.HealthChangedEvent += OnHealthChanged;
            }
        }

        private void Start() 
        {
            _inhibitor.HealthSystem.HealthChangedEvent += OnHealthChanged;
        }

        private void OnDisable() 
        {
            _inhibitor.HealthSystem.HealthChangedEvent -= OnHealthChanged;                
        }

        private void OnHealthChanged()
        {
            _healthBarUI.SetBarUI(_inhibitor.HealthSystem.GetHealthPercent());
            squashAndStretch.PlaySquashAndStretch();
        }
    }
}
