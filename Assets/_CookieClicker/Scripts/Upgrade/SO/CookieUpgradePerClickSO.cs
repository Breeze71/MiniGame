using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.CookieClicker
{
    /// <summary>
    /// 每次更新增加 數量
    /// </summary>
    [CreateAssetMenu(menuName = "Cookie Upgrade/Cookies Per Click", fileName = "Cookies Per Click")]
    public class CookieUpgradePerClickSO : CookieUpgradeSOBase
    {
        public override void ApplyUpgrade()
        {
            CookieManager.Instance.CookiesPerClickUpgrade += UpgradeAmount;
        }
    }
}
