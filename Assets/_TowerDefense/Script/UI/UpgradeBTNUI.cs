using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace V.TowerDefense
{
    public class UpgradeBTNUI : MenuBTNBase
    {
        // health display
        // atk dis
        // soilder so
        [field : SerializeField] public Button Button {get; private set;}

        [SerializeField] private TextMeshProUGUI _upgradeCostTEXT;

        [SerializeField] private TextMeshProUGUI _attackTEXT;
        [SerializeField] private TextMeshProUGUI _attackUpTEXT;
        [SerializeField] private TextMeshProUGUI _healthTEXT;
        [SerializeField] private TextMeshProUGUI _healthUpTEXT;
        
        private void Awake() 
        {
            Button = GetComponentInChildren<Button>();    
        }

        protected override void Start() 
        {
            UpdateUpgradeBTNUI(SoilderConfig);
        }
        
        private void OnDestroy() 
        {
            UpdateUpgradeBTNUI(SoilderConfig); 
        }

        private void UpdateUpgradeCost(int value)
        {
            _upgradeCostTEXT.text = value.ToString();
        }
        private void UpdateUpgradeValue()
        {
            _attackTEXT.text = SoilderConfig.CurrentAttack.ToString();
            _healthTEXT.text = SoilderConfig.CurrentHealth.ToString();
        }

        public void UpdateUpgradeUpValue(int atkUp, int healthUp)
        {
            _attackUpTEXT.text = "+" + atkUp.ToString();
            _healthUpTEXT.text = "+" + healthUp.ToString();
        }

        public void UpdateUpgradeBTNUI(UnitSO unitSO)
        {
            if(SoilderConfig != null)
            {
                UpdateUpgradeValue();
                UpdateUpgradeCost(unitSO.CurrentLevel);
            }
            else
            {
                _attackTEXT.text = "---";
                _healthTEXT.text = "---";
                _upgradeCostTEXT.text = "---";
                _attackUpTEXT.text = "---";
                _healthUpTEXT.text = "---";
                _attackUpTEXT.enabled = false;
                _healthUpTEXT.enabled = false;
            }
        }
    }
}
