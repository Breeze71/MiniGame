using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.CookieClicker
{
    [CreateAssetMenu(menuName = "Cookie Upgrade/Cookies Per Second", fileName = "Cookies Per Second")]
    public class CookieUpgradePerSecondSO : CookieUpgradeSOBase
    {
        public override void ApplyUpgrade()
        {
            GameObject _UpgradePerSecGO = Instantiate(CookieManager.Instance.CookiePerSecondObjToSpawn, Vector3.zero, Quaternion.identity);
            _UpgradePerSecGO.GetComponent<CookiePerSecondTimer>().CookiePerSecond = UpgradeAmount;

            CookieManager.Instance.SimpleCookiePerSecondIncrease(UpgradeAmount);
        }
    }
}
