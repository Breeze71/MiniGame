using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using V.CookieClicker;

namespace V.TowerDefense
{
    public class GameEventManager : MonoBehaviour
    {
        public static GameEventManager I {get; private set;}

        public event Action<SoldierBTNUI> OnSummonUnitEvent;
        public event Action<UpgradeBTNUI> OnUpgradeEvent;
        public event Action<int> OnMoneyChangedEvent;

        private int CoinAmount = 100; 
        private int currentCost = 1;

        #region LC
        private void Awake() 
        {
            if(I != null)
            {
                Debug.LogWarning("More than one Game Manager Singleton");
                return;
            }    
            I = this;
        }
        #endregion

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
