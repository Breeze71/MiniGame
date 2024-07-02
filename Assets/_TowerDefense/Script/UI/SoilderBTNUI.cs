using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
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

        private void Awake() 
        {
            Button = GetComponentInChildren<Button>();    
        }
    }
}
