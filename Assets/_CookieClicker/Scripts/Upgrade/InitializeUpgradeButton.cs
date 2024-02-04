using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.CookieClicker
{
    /// <summary>
    /// 生成對應 CookieUpgradeSOBase 數量的 升級按鈕(設置好名字及 OnClick)
    /// </summary>
    public class InitializeUpgradeButton : MonoBehaviour
    {
        public void InitializeButton(CookieUpgradeSOBase[] _cookieUpgradeSOBases, GameObject _UIToSpawn, Transform spawnParent)
        {
            for(int i = 0; i < _cookieUpgradeSOBases.Length; i++)
            {
                int _currentIndex = i;

                GameObject _upgradeButtonGO = Instantiate(_UIToSpawn, spawnParent);

                // Reset cost
                _cookieUpgradeSOBases[_currentIndex].CurrentUpgradeCost = _cookieUpgradeSOBases[_currentIndex].OriginUpgradeCost;

                // Set Text
                UpgradeButtonUI _upgradeButtonUI = _upgradeButtonGO.GetComponent<UpgradeButtonUI>();
                _upgradeButtonUI.UpgradeButtonTEXT.text = _cookieUpgradeSOBases[_currentIndex].UpgradeButtonText;
                _upgradeButtonUI.UpgradeDescriptionTEXT.SetText(_cookieUpgradeSOBases[_currentIndex].UpgradeButtonDescription
                    , _cookieUpgradeSOBases[_currentIndex].UpgradeAmount);
                _upgradeButtonUI.UpgradeCostTEXT.text = "Cost: " + _cookieUpgradeSOBases[_currentIndex].CurrentUpgradeCost;

                // On Click
                _upgradeButtonUI.UpgradeBUTTON.onClick.AddListener(delegate
                {
                    CookieManager.Instance.OnUpgradeButtonClick(_cookieUpgradeSOBases[_currentIndex], _upgradeButtonUI);
                });
            }
        }
        
    }
}
