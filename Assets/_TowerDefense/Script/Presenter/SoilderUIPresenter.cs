using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class SoilderUIPresenter : MonoBehaviour
    {
        [SerializeField] private SoilderUI _soilderUI;
        [SerializeField] private SoilderSpawner _soilderSpawner;
        private void OnEnable() 
        {
            _soilderUI.SoilderBTNEvent += SoilderUI_SoilderBTNEvent;
        }

        private void SoilderUI_SoilderBTNEvent(SoldierBTNUI buttonUI)
        {
            // spawn soilder
            Debug.Log("btn press");
            _soilderSpawner.SpawnSoilder(buttonUI.soilderConfig.soilderPrefabs);
        }
    }
}
