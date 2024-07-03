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

        public event Action<SoldierBTNUI> OnMoneyEnoughEvent;
        public event Action<int> OnMoneyChangedEvent;

        private int CoinAmount = 100; 

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

        #region Money Change
        public void CostMoney(SoldierBTNUI buttonUI)
        {
            int cost = buttonUI.soilderConfig.Cost;

            if(CoinAmount >= cost)
            {
                CoinAmount -= cost;
                OnMoneyEnoughEvent?.Invoke(buttonUI);
                OnMoneyChangedEvent?.Invoke(CoinAmount);
            }
            else
            {
                Debug.LogWarning("Money Not Enough");
            }
        }

        public void IncreaseMoney(int amount)
        {
            CoinAmount += amount;
            OnMoneyChangedEvent?.Invoke(CoinAmount);
        }

        #endregion
    }
}
