using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace V.CookieClicker
{
    /// <summary>
    /// 避免按圖片外仍然觸發 Button OnClick ( 圖片必須 fullRect and read/write)
    /// </summary>
    public class CookieHitAlphaThreshold : MonoBehaviour
    {
        private Image cookieImage;
        private void Awake() 
        {
            cookieImage = GetComponent<Image>();
            cookieImage.alphaHitTestMinimumThreshold = 0.001f;
        }
    }
}
