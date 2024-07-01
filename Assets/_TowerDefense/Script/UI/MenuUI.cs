using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace V.TowerDefense
{
    public class MenuUI : MonoBehaviour
    {
        public event Action SoiderBTNEvent;
        public event Action UpgradeBTNEvent;
        public event Action StoreBTNEvent;

        [SerializeField] private Button _soilderBTN;
        [SerializeField] private Button _upgradeBTN;
        [SerializeField] private Button _storeBTN;

        private void Awake() 
        {
            _soilderBTN.onClick.AddListener(() => SoiderBTNEvent?.Invoke());
            _upgradeBTN.onClick.AddListener(() => UpgradeBTNEvent?.Invoke());
            _storeBTN.onClick.AddListener(() => StoreBTNEvent?.Invoke());
        }
    }
}
