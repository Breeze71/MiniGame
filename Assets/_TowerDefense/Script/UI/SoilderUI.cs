using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace V.TowerDefense
{
    public class SoilderUI : MonoBehaviour
    {
        public event Action<SoilderBTNUI> SoilderBTNEvent;

        [SerializeField] private List<SoilderBTNUI> _soilderBTNs;

        private void Awake() 
        {
            _soilderBTNs = new List<SoilderBTNUI>(GetComponentsInChildren<SoilderBTNUI>());
        }

        private void Start() 
        {
            foreach(SoilderBTNUI soilderBTN in _soilderBTNs)
            {
                soilderBTN.Button.onClick.AddListener(() =>
                {
                    SoilderBTNEvent?.Invoke(soilderBTN);
                });
            }
        }
    }
}
