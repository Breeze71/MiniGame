using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace V.TowerDefense
{
    public class SoldierBTNUI : MenuBTNBase
    {
        // health display
        // atk dis
        // soilder so
        [field : SerializeField] public Button Button {get; private set;}

        [SerializeField] private TextMeshProUGUI _attackTEXT;
        [SerializeField] private TextMeshProUGUI _healthTEXT;

        private void Awake() 
        {
            Button = GetComponentInChildren<Button>();    

            if(SoilderConfig != null)
            {
                SoilderConfig.ResetUnitSO();
            }
        }

        private void OnEnable() 
        { 
            UpdateSoldierUI();
        }

        protected override void Start() 
        {
            base.Start();
            
            UpdateSoldierUI();    
        }

        private void OnDisable() 
        {
            UpdateSoldierUI();
        }

        private void OnDestroy() 
        {
            if(SoilderConfig != null)
            {
                SoilderConfig.ResetUnitSO();
            }             
        }

        private void OnUpgrade()
        {
            UpdateSoldierUI();
        }

        public void UpdateSoldierUI()
        {
            if(SoilderConfig != null)
            {
                Debug.Log("update soilder ui");

                _attackTEXT.text = SoilderConfig.CurrentAttack.ToString();
                _healthTEXT.text = SoilderConfig.CurrentHealth.ToString();
            }
            else
            {
                _attackTEXT.text = "---";
                _healthTEXT.text = "---";
            }
        }
    }
}
