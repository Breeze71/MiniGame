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

        [SerializeField] private UnitUpgrade _unitUpgrade;

        [SerializeField] private Image _iconIMG;
        [SerializeField] private TextMeshProUGUI _upgradeCostTEXT;

        [SerializeField] private TextMeshProUGUI _attackTEXT;
        [SerializeField] private TextMeshProUGUI _attackUpTEXT;
        [SerializeField] private TextMeshProUGUI _healthTEXT;
        [SerializeField] private TextMeshProUGUI _healthUpTEXT;
        
        #region LC
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
        #endregion

        private void UpdateUpgradeCost(int value)
        {
            NumDisplay(value, _upgradeCostTEXT);
        }
        private void UpdateUpgradeValue()
        {
            NumDisplay(SoilderConfig.CurrentAttack, _attackTEXT);
            NumDisplay(SoilderConfig.CurrentHealth, _healthTEXT);
        }

        public void UpdateUpgradeUpValue(int atkUp, int healthUp)
        {
            NumDisplay(atkUp, _attackUpTEXT, "+");
            NumDisplay(healthUp, _healthUpTEXT, "+");
        }

        public void UpdateUpgradeBTNUI(UnitSO unitSO)
        {
            if(SoilderConfig != null)
            {
                _iconIMG.sprite = SoilderConfig.Img;

                int atkUp = _unitUpgrade.NextUpgradeValue(SoilderConfig.CurrentAttack, SoilderConfig.UpgradeMultiplier);
                int hpUp = _unitUpgrade.NextUpgradeValue(SoilderConfig.CurrentHealth, SoilderConfig.UpgradeMultiplier);
                UpdateUpgradeUpValue(atkUp, hpUp);

                UpdateUpgradeValue();
                UpdateUpgradeCost(unitSO.CurrentLevel);
            }
            else
            {
                _iconIMG.sprite = null;
                
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
