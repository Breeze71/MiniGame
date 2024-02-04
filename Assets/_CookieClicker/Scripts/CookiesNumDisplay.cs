using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace V.CookieClicker
{
    /// <summary>
    /// 科學記數 (K thousand, M million, B billion, T trillion, Q quadrillion)
    /// </summary>
    public class CookiesNumDisplay : MonoBehaviour
    {
        /// <summary>
        /// 將純數字轉為科學計數
        /// </summary>
        /// <param name="_cookieCount"> 當前數目 </param>
        /// <param name="_textToChange"> TextMeshPro </param>
        /// <param name="_optionalEndText"> 結尾字 </param>
        public void UpdateCookieText(double _cookieCount, TextMeshProUGUI _textToChange, string _optionalEndText = null)
        {
            string[] _suffixes = {"", "K", "M", "B", "T", "Q"};
            int _suffixesIndex = 0;

            // 當能進位時
            while(_cookieCount >= 1000 && _suffixesIndex < _suffixes.Length -1)
            {
                _cookieCount /= 1000;
                _suffixesIndex++;

                // 超出最大進位的值(沒命名了，大於 quadrillion)
                if(_suffixesIndex >= _suffixes.Length -1 && _cookieCount >= 1000)
                {
                    break;
                }
            }

            // 依 index 給予 Formatted String
            string _formattedText;
            if(_suffixesIndex == 0)
            {
                _formattedText = _cookieCount.ToString();
            }
            else
            {
                _formattedText = _cookieCount.ToString("F1") + _suffixes[_suffixesIndex];
            }

            _textToChange.text = _formattedText + _optionalEndText;

        }
    }
}
