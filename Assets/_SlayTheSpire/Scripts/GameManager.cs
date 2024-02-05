using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using V.SlayTheSpire.Data;
using V.SlayTheSpire.UI;

namespace V.SlayTheSpire
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            GameConfigManager.Instance.InitConfig();

            UIManager.Instance.ShowUI<LoginUI>("LoginUI");    

            AudioManager.Instance.PlayBGM("bgm1");

            string name = GameConfigManager.Instance.GetCardById("1001")["Name"]; // Dictionary
            Debug.Log(name);
        }
    }
}
