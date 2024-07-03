using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class UpgradeUI : MonoBehaviour
    {
        public event Action<UpgradeBTNUI> UpgradeBTNEvent;

        [SerializeField] private List<UpgradeBTNUI> _upgradeBTNs;

        private void Awake() 
        {
            _upgradeBTNs = new List<UpgradeBTNUI>(GetComponentsInChildren<UpgradeBTNUI>());
        }

        private void Start() 
        {
            foreach(UpgradeBTNUI upgradeBTN in _upgradeBTNs)
            {
                upgradeBTN.Button.onClick.AddListener(() =>
                {
                    UpgradeBTNEvent?.Invoke(upgradeBTN);
                });
            }
        }
    }
}
