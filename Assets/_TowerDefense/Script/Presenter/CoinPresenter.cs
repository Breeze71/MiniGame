using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class CoinPresenter : MonoBehaviour
    {
        [SerializeField] private CoinUI _coinUI;

        private void OnEnable() 
        {
            GameEventManager.I.OnMoneyChangedEvent += GameEventManager_I_OnMoneyChangedEvent;
        }
        private void OnDisable() 
        {
            GameEventManager.I.OnMoneyChangedEvent -= GameEventManager_I_OnMoneyChangedEvent;
        }

        private void GameEventManager_I_OnMoneyChangedEvent(int amount)
        {
            _coinUI.SetCoinText(amount);
        }
    }
}
