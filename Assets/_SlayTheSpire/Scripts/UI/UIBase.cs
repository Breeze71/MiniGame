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
