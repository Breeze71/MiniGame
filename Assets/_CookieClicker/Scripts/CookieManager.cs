using System.Collections;
using System.Collections.Generic;
using System.Net;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

namespace V.CookieClicker
{
    public class CookieManager : MonoBehaviour
    {
        public static CookieManager Instance { get; set;}

        [Header("CountText")]
        [SerializeField] private TextMeshProUGUI cookieCountText;
        [SerializeField] private TextMeshProUGUI cookiePerSecondText;

        [Space]
        public GameObject MainGameCanvas;
        [SerializeField] private GameObject upgradeCanvas;
        [SerializeField] private GameObject cookieObj;
        [SerializeField] private GameObject backgroundObj;

        public GameObject CookieTextPopup;

        [Space]
        [SerializeField] private GameObject upgradeUIToSpawn;
        [SerializeField] private Transform upgradeUIParent;

        public GameObject CookiePerSecondObjToSpawn;

        public double CurrentCookiesCount { get; set; }
        public double CurrentCookiesPerSecond { get; set; }

        [Header("Upgrade")]
        public CookieUpgradeSOBase[] CookieUpgradeSOBases;
        private InitializeUpgradeButton initializeUpgradeButton;
        public double CookiesPerClickUpgrade { get; set; }

        [Header("Formatted Display Num")]
        private CookiesNumDisplay cookiesNumDisplay;

        #region Life Cycle
        private void Awake() 
        {
            if(Instance != null)
            {
                Debug.LogError("More than one cookie Manager Instance");
            }

            Instance = this;

            cookiesNumDisplay = GetComponent<CookiesNumDisplay>();
            initializeUpgradeButton = GetComponent<InitializeUpgradeButton>();
        }

        private void Start() 
        {
            UpdateCookieCountText();
            UpdateCookiePerSecondText();

            upgradeCanvas.SetActive(false);
            MainGameCanvas.SetActive(true);

            initializeUpgradeButton.InitializeButton(CookieUpgradeSOBases, upgradeUIToSpawn, upgradeUIParent);
        }
        #endregion

        #region On Cookie Click
        public void OnCoolieClicked()
        {
            IncreaseCookie();

            cookieObj.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(CookieScaleBack);
            backgroundObj.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(BackgroundScaleBack);
        
            PopupTextUI.Create(1 + CookiesPerClickUpgrade);
        } 

        private void CookieScaleBack()
        {
            cookieObj.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
        }
        private void BackgroundScaleBack()
        {
            backgroundObj.transform.DOBlendableScaleBy(new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
        }

        public void IncreaseCookie()
        {
            CurrentCookiesCount += 1 + CookiesPerClickUpgrade;

            UpdateCookieCountText();
        }
        #endregion

        #region UI Update
        private void UpdateCookieCountText()
        {
            // cookieCountText.text = CurrentCookiesCount.ToString();
            cookiesNumDisplay.UpdateCookieText(CurrentCookiesCount, cookieCountText);
        }
        private void UpdateCookiePerSecondText()
        {
            // cookiePerSecondText.text = CurrentCookiesPerSecond.ToString() + " P/S";
            cookiesNumDisplay.UpdateCookieText(CurrentCookiesPerSecond, cookiePerSecondText, " P/S");
        }
        #endregion
    
        #region Button Press
        public void OnUpgradeButton()
        {
            // mainGameCanvas.SetActive(false);
            upgradeCanvas.SetActive(true);
        }
        public void OnResumeButton()
        {
            // mainGameCanvas.SetActive(true);
            upgradeCanvas.SetActive(false);
        }
        #endregion
    
        #region Simple Increase
        public void SimpleCookieIncrease(double _amount)
        {
            CurrentCookiesCount += _amount;
            UpdateCookieCountText();
        }
        public void SimpleCookiePerSecondIncrease(double _amount)
        {
            CurrentCookiesPerSecond += _amount;
            UpdateCookiePerSecondText();
        }
        #endregion
    
        #region Upgrade Button Click
        /// <summary>
        /// 升級餅乾產生數量
        /// </summary>
        public void OnUpgradeButtonClick(CookieUpgradeSOBase _cookieUpgradeSOBase, UpgradeButtonUI _upgradeButtonUI)
        {
            if(CurrentCookiesCount >= _cookieUpgradeSOBase.CurrentUpgradeCost)
            {
                _cookieUpgradeSOBase.ApplyUpgrade();

                // 扣掉升級數
                CurrentCookiesCount -= _cookieUpgradeSOBase.CurrentUpgradeCost;
                UpdateCookieCountText();
                
                // 計算下次升級花費
                _cookieUpgradeSOBase.CurrentUpgradeCost = 
                    Mathf.Round((float)(_cookieUpgradeSOBase.CurrentUpgradeCost * (1 + _cookieUpgradeSOBase.CostIncreaseMultiplierPerPurchase)));
                _upgradeButtonUI.UpgradeCostTEXT.text = "Cost: " + _cookieUpgradeSOBase.CurrentUpgradeCost;
            }
        }
        #endregion
    }
}
