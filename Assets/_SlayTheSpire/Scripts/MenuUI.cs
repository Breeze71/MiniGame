using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using V.SlayTheSpire.UI;

namespace V.SlayTheSpire
{
    public class MenuUI : MonoBehaviour
    {
        private void Start()
        {
            UIManager.Instance.ShowUI<LoginUI>("LoginUI");    
        }
    }
}
