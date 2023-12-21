using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] private GameObject upgradeCanvas;
        [SerializeField] private GameObject mainGameCanvas;
        [SerializeField] private GameObject cookieObj;
        [SerializeField] private GameObject backgroundObj;

        public GameObject CookieTextPopup;

        [Space]
        [SerializeField] private GameObject upgradeUIToSpawn;
        [SerializeField] private Transform upgradeUIParent;

        public GameObject CookiePerSecondObjToSpawn;

        public double CurrentCookiesCount { get; set; }
        public double CurrentCookiesPerSecond { get; set; }
        public double CookiesPerClickUpgrade { get; set; }

        #region Life Cycle
        private void Awake() 
        {
            if(Instance != null)
            {
                Debug.LogError("More than one cookie Manager Instance");
            }

            Instance = this;
        }

        private void Start() 
        {
            UpdateCookieCountText();
            UpdateCookiePerSecondText();

            upgradeCanvas.SetActive(false);
            mainGameCanvas.SetActive(true);
        }
        #endregion

        #region On Cookie Click
        public void OnCoolieClicked()
        {
            IncreaseCookie();

            cookieObj.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(CookieScaleBack);
            backgroundObj.transform.DOBlendableScaleBy(new Vector3(0.05f, 0.05f, 0.05f), 0.05f).OnComplete(BackgroundScaleBack);
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
            cookieCountText.text = CurrentCookiesCount.ToString();
        }
        private void UpdateCookiePerSecondText()
        {
            cookiePerSecondText.text = CurrentCookiesPerSecond.ToString() + " P/S";
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
    }
}
