using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using V.CookieClicker;
using V.Utilities;

namespace V.CookieClicker
{
    /// <summary>
    ///  Pop Up Text Effect
    /// </summary>
    public class PopupTextUI : MonoBehaviour
    {
        [SerializeField] private float startVelocityY = 750f;
        [SerializeField] private float velocityDecayRate = 1500f;
        [SerializeField] private float timeBeforeFadeStart = .6f;
        [SerializeField] private float fadeSpeed = 3f;

        private TextMeshProUGUI clickAmountText;

        private Vector2 currentVelocity;

        private Color startColor;
        private float timer;
        private float textAlpha;

        public static PopupTextUI Create(double _amount)
        {
            GameObject _popupGO = ObjectPoolManager.SpawnObject(CookieManager.Instance.CookieTextPopup
                , CookieManager.Instance.MainGameCanvas.transform);
            _popupGO.transform.position = CookieManager.Instance.MainGameCanvas.transform.position;

            PopupTextUI _cookiePopupText = _popupGO.GetComponent<PopupTextUI>();
            _cookiePopupText.Init(_amount);

            return _cookiePopupText;
        }

        public void Init(double _amount)
        {
            clickAmountText.text = "+" + _amount.ToString("0");

            // 生成跳出
            float _randomX = Random.Range(-300f, 300f);
            currentVelocity = new Vector2(_randomX, startVelocityY);
        }

        #region Life Cycle
        private void OnEnable() 
        {
            clickAmountText = GetComponent<TextMeshProUGUI>();

            Color _newColor = clickAmountText.color;
            _newColor.a = 1f;

            startColor = _newColor;

            timer = 0f;
            textAlpha = 1f;
        }
        private void Update()
        {
            currentVelocity.y -= Time.deltaTime * velocityDecayRate;
            transform.Translate(currentVelocity * Time.deltaTime);

            timer += Time.deltaTime;
            if(timer > timeBeforeFadeStart)
            {
                textAlpha -= Time.deltaTime * fadeSpeed;

                startColor.a = textAlpha;
                clickAmountText.color = startColor;

                // 回收
                if(textAlpha <= 0f)
                {
                    ObjectPoolManager.ReturnObjectToPool(gameObject);
                }
            }
        }
        #endregion
    }
}
