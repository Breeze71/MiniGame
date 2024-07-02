using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace V.TowerDefense
{
    public class SoilderBTNUI : MonoBehaviour
    {
        // health display
        // atk dis
        // soilder so
        [Expandable] public SoilderSO soilderConfig;
        [field : SerializeField] public Button Button {get; private set;}

        [SerializeField] private TextMeshProUGUI _attackTEXT;
        [SerializeField] private TextMeshProUGUI _healthTEXT;

        private void Awake() 
        {
            Button = GetComponentInChildren<Button>();    
        }

        private void Start() 
        {
            UpdateSoldierUI();    
        }

        public void UpdateSoldierUI()
        {
            if(soilderConfig != null)
            {
                _attackTEXT.text = soilderConfig.Attack.ToString();
                _healthTEXT.text = soilderConfig.Health.ToString();
            }
            else
            {
                _attackTEXT.text = "---";
                _healthTEXT.text = "---";
            }
        }
    }
}
