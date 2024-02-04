using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.SlayTheSpire.UI
{
    /// <summary>
    /// Base Class Of UI
    /// </summary>
    public class UIBase : MonoBehaviour
    {
        /// <summary>
        /// 訂閱 OnPointerClick Event (ui 下的 button 用)
        /// </summary>
        public UIEventTrigger RegisterEvent(string _name)
        {
            Transform _tf = transform.Find(_name);

            return UIEventTrigger.GetUIEventTrigger(_tf.gameObject);
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void Close()
        {
            UIManager.Instance.CloseUI(gameObject.name);
        }
    }
}
