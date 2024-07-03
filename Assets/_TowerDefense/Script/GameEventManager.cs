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
                Debug.LogError("Money Not Enough");
            }
        }

        public void GetMoney()
        {

        }
    }
}
