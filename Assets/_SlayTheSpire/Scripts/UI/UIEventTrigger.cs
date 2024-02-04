using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace V.SlayTheSpire.UI
{
    /// <summary>
    /// IPointerClickHandler 事件監聽
    /// </summary>
    public class UIEventTrigger : MonoBehaviour, IPointerClickHandler
    {
        public event Action<GameObject, PointerEventData> OnClickEvent;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickEvent?.Invoke(gameObject, eventData);
        }

        /// <summary> ***
        /// Static Fuction 獲取某 go 的 UIEventTrigger，若他沒有，加上
        /// </summary> ***
        public static UIEventTrigger GetUIEventTrigger(GameObject _go)
        {
            UIEventTrigger _trigger = _go.GetComponent<UIEventTrigger>();
            if(_trigger == null)
            {
                _trigger = _go.AddComponent<UIEventTrigger>();
            }

            return _trigger;
        }
    }
}
