using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using V.SlayTheSpire.UI;
using System;

namespace V.SlayTheSpire.UI
{
    public class LoginUI : UIBase
    {
        private void Awake() 
        {
            RegisterEvent("bg/startBtn").OnClickEvent += StartBtn_OnClick;
        }

        /// <summary>
        /// 關閉 LoginUI
        /// </summary>
        private void StartBtn_OnClick(GameObject @object, PointerEventData data)
        {
            Close();
        }
    }
}
