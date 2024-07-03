using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace V.TowerDefense
{
    public class SoldierUI : MonoBehaviour
    {
        public event Action<SoldierBTNUI> SoilderBTNEvent;

        [SerializeField] private List<SoldierBTNUI> _soilderBTNs;

        private void Awake() 
        {
            _soilderBTNs = new List<SoldierBTNUI>(GetComponentsInChildren<SoldierBTNUI>());
        }

        private void Start() 
        {
            foreach(SoldierBTNUI soilderBTN in _soilderBTNs)
            {
                soilderBTN.Button.onClick.AddListener(() =>
                {
                    SoilderBTNEvent?.Invoke(soilderBTN);
                });
            }
        }
    }
}
