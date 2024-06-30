using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace V.TowerDefense
{
    public class CoinUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinText;

        public void SetCoinText(int amount)
        {
            _coinText.text = amount.ToString();
        }
    }
}
