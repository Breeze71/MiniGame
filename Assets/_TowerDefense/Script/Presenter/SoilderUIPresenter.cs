using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class SoilderUIPresenter : MonoBehaviour
    {
        [SerializeField] private SoldierUI _soilderUI;
        [SerializeField] private SoilderSpawner _soilderSpawner;
        
        private void OnEnable() 
        {
            _soilderUI.SoilderBTNEvent += SoilderUI_SoilderBTNEvent;
            GameEventManager.I.OnMoneyEnoughEvent += GameEventManager_I_OnMoneyEnoughEvent;
        }
        private void OnDisable() 
        {
            _soilderUI.SoilderBTNEvent -= SoilderUI_SoilderBTNEvent;
            GameEventManager.I.OnMoneyEnoughEvent -= GameEventManager_I_OnMoneyEnoughEvent;
        }

        private void SoilderUI_SoilderBTNEvent(MenuBTNBase bTNUI)
        {
            // cost money
            GameEventManager.I.SummonUnit(bTNUI);
        }

        private void GameEventManager_I_OnMoneyEnoughEvent(MenuBTNBase bTNUI)
        {
            // spawn soilder
            _soilderSpawner.SpawnSoilder(bTNUI.SoilderConfig.soilderPrefabs);
        }
    }
}
