using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
}
