using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.CookieClicker
{
    public abstract class CookieUpgradeSOBase : ScriptableObject
    {
        public float UpgradeAmount = 1f;

        public double OriginUpgradeCost = 100;
        public double CurrentUpgradeCost = 100;
        public double CostIncreaseMultiplierPerPurchase = 0.05f; // 每次升級，下次升級會乘以倍數

        public string UpgradeButtonText;    

        [TextArea(3, 10)]
        public string UpgradeButtonDescription;

        public abstract void ApplyUpgrade();

        /// <summary>
        /// 腳本加載時，重置
        /// </summary>
        private void OnValidate() 
        {
            CurrentUpgradeCost = OriginUpgradeCost;    
        }
    }
}
