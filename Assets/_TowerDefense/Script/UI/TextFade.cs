using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using System;

namespace V.TowerDefense
{
    public class TextFade : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        [SerializeField] private TextMeshProUGUI _tipText;
        [SerializeField] private float _duration = .5f;
        [SerializeField] private Color _flashColor;
        // [SerializeField] private float _yOffest = 0.5f;
        // [SerializeField] private float _delay = 0.0f;

        private Vector3 _originScale;

        private void OnEnable() 
        {
            InputManager.Instance.TapEvent += OnScreenTap;    
        }

        private void OnScreenTap()
        {
            _rectTransform.gameObject.SetActive(false);
        }

        private void Start() 
        {
            _tipText = _rectTransform.GetComponent<TextMeshProUGUI>();
            // _tipText.DOFade(0, 0);

            _originScale = _rectTransform.localScale;
            _rectTransform.localScale = _originScale / 4f;

            PlayFade();
        }

        private void OnDisable() 
        {
            InputManager.Instance.TapEvent -= OnScreenTap;                  
        }

        private void PlayFade()
        {
            Sequence s = DOTween.Sequence();
            s.Append(_rectTransform.DOScale(_originScale, _duration).SetEase(Ease.OutCirc));
            // s.Join(_tipText.DOColor(_flashColor, _duration).SetDelay(_duration / 2f));

            s.Join(_tipText.DOFade(1, _duration / 3));
            s.Join(_tipText.DOFade(.75f, _duration / 4).SetDelay(_duration / 1.5f));
            // s.Join(_rectTransform.DOMoveY(_yOffest, _duration).SetEase(Ease.OutCirc));

            s.SetLoops(-1);
        }
    }
}
