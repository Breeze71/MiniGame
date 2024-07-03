using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class UnitUpgrade : MonoBehaviour
    {
        // public int 

        public void UpgradeUnit(UnitSO unitSO)
        {
            unitSO.CurrentAttack = UpgradeValue(unitSO.CurrentAttack, unitSO.UpgradeMultiplier);
            unitSO.CurrentHealth = UpgradeValue(unitSO.CurrentHealth, unitSO.UpgradeMultiplier);
            
            unitSO.CurrentLevel += 1;
        }

        public int NextUpgradeValue(int value, float upgradeMeltiplier)
        {
            return (int)UpgradeValue(value, upgradeMeltiplier) - value;
        }

        private int UpgradeValue(int value, float upgradeMeltiplier)
        {
            return (int)Mathf.Round(value * (1 + upgradeMeltiplier));
        }
    }
}
