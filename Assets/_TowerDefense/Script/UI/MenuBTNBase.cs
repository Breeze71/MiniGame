using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace V.TowerDefense
{
    public class MenuBTNBase : MonoBehaviour
    {
        [Expandable] public UnitSO SoilderConfig;

        protected virtual void Start() 
        {
            
        }

        protected void NumDisplay(int value, TextMeshProUGUI textToChange, string optionalStartText = null, string optionalEndText = null)
        {
            string[] _suffixes = {"", "K", "M", "B", "T", "Q"};
            int _suffixesIndex = 0;

            // 當能進位時
            while(value >= 1000 && _suffixesIndex < _suffixes.Length -1)
            {
                value /= 1000;
                _suffixesIndex++;

                // 超出最大進位的值(沒命名了，大於 quadrillion)
                if(_suffixesIndex >= _suffixes.Length -1 && value >= 1000)
                {
                    break;
                }
            }

            // 依 index 給予 Formatted String
            string _formattedText;
            if(_suffixesIndex == 0)
            {
                _formattedText = value.ToString();
            }
            else
            {
                _formattedText = value.ToString("F1") + _suffixes[_suffixesIndex];
            }

            textToChange.text = optionalStartText + _formattedText + optionalEndText;
        }
    }
}
