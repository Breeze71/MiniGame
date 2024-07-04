using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using V.CookieClicker;

namespace V.TowerDefense
{
    public class CoinEvent
    {
        public event Action<SoldierBTNUI> OnSummonUnitEvent;
        public event Action<UpgradeBTNUI> OnUpgradeEvent;
        public event Action<int> OnMoneyChangedEvent;

        private int CoinAmount = 100; 
        private int currentCost = 1;

        public void IncreaseMoney(int amount)
        {
            CoinAmount += amount;
            OnMoneyChangedEvent?.Invoke(CoinAmount);
        }

        // summon unit
        public void SummonUnit(SoldierBTNUI buttonUI)
        {
            int cost = buttonUI.SoilderConfig.SummonCost;

            CostMoney(buttonUI, cost);
            OnSummonUnitEvent?.Invoke(buttonUI);
        }

        // upgrade unit
        public void UpgradeUnit(UpgradeBTNUI buttonUI)
        {
            CostMoney(buttonUI, currentCost);
            
            currentCost = (int)Mathf.Round(buttonUI.SoilderConfig.CurrentLevel * 
                    (1 + buttonUI.SoilderConfig.UpgradeMultiplierPerPurchase));

            OnUpgradeEvent?.Invoke(buttonUI);
        }

        private void CostMoney(MenuBTNBase buttonUI, int cost)
        {
            if(CoinAmount >= cost)
            {
                CoinAmount -= cost;
                OnMoneyChangedEvent?.Invoke(CoinAmount);
            }
            else
            {
                Debug.LogWarning("Money Not Enough");
            }            
        }
    }
}
