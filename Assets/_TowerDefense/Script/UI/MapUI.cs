using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace V.TowerDefense
{
    public class MapUI : MonoBehaviour
    {
        [SerializeField] private Button[] levelBTNs;

        private void Start() 
        {
            for(int i = 0; i < levelBTNs.Length; i++)
            {
                int index = i + 1; // lambda 只取引用，故需保存每次 i
                levelBTNs[i].onClick.AddListener(() =>
                {
                    Loader.LoadScene((EScene)Enum.ToObject(typeof(EScene), index));
                });
            }    
        }
    }
}
