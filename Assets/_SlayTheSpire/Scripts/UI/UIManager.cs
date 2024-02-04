using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace V.SlayTheSpire.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance {get; private set;}

        [SerializeField] private Transform canvasTransform;
        private List<UIBase> uiList;

        #region LifeCycle
        private void Awake() 
        {
            if(Instance != null)
            {
                Debug.LogError("There is more than one UIManager Instance");
            }

            Instance = this;    
        }

        private void Start() 
        {
            uiList = new List<UIBase>();    
        }
        #endregion

        /// <summary>
        /// Display the UIBase sub Class
        /// </summary>
        public UIBase ShowUI<T>(string _uiName) where T : UIBase
        {
            UIBase _ui = FindUIByName(_uiName);

            // 如果沒有，從 Resource / UI 加入
            if(_ui == null)
            {
                GameObject _go = Instantiate(Resources.Load("UI/" + _uiName), canvasTransform) as GameObject;

                _go.name = _uiName; // 改名

                _ui = _go.AddComponent<T>(); // 加入相應 Scripts

                uiList.Add(_ui); // add to list
            }

            else
            {
                _ui.Show();
            }

            return _ui;
        }

        public void HideUI(string _uiName)
        {
            UIBase _ui = FindUIByName(_uiName);
            if(_ui != null)
            {
                _ui.Hide();
            }
        }

        // Destory UI
        public void CloseUI(string _uiName)
        {
            UIBase _ui = FindUIByName(_uiName);
            if(_ui != null)
            {
                uiList.Remove(_ui);

                Destroy(_ui.gameObject);
            }
        }

        public void CloseAllUI()
        {
            foreach(UIBase _ui in uiList)
            {
                Destroy(_ui.gameObject);
            }

            uiList.Clear();
        }

        public UIBase FindUIByName(string _uiName)
        {
            for(int i = 0; i < uiList.Count; i++)
            {
                if(uiList[i].name == _uiName)
                {
                    return uiList[i];
                }
            }

            return null;
        }
    }
}
