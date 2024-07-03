using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class UpgradePresenter : MonoBehaviour
    {
        [SerializeField] private UpgradeUI _upgradeUI;
        [SerializeField] private UnitUpgrade _unitUpgrade;

        private void OnEnable() 
        {
            _upgradeUI.UpgradeBTNEvent += UpgradeUI_UpgradeBTN;
            GameEventManager.I.OnUpgradeEvent += GameEventManager_I_OnUpgrade;
        }

        private void OnDisable() 
        {
            _upgradeUI.UpgradeBTNEvent -= UpgradeUI_UpgradeBTN;
        }

        private void UpgradeUI_UpgradeBTN(UpgradeBTNUI bTNUI)
        {
            GameEventManager.I.UpgradeUnit(bTNUI);
        }

        private void GameEventManager_I_OnUpgrade(UpgradeBTNUI bTNBase)
        {

            if(bTNBase == null)    return;

            _unitUpgrade.UpgradeUnit(bTNBase.SoilderConfig); // up

            bTNBase.UpdateUpgradeBTNUI(bTNBase.SoilderConfig); // ui

            int atkUp = _unitUpgrade.NextUpgradeValue(bTNBase.SoilderConfig.CurrentAttack, bTNBase.SoilderConfig.UpgradeMultiplier);
            int hpUp = _unitUpgrade.NextUpgradeValue(bTNBase.SoilderConfig.CurrentHealth, bTNBase.SoilderConfig.UpgradeMultiplier);
            bTNBase.UpdateUpgradeUpValue(atkUp, hpUp); // ui
        }

    }
}
