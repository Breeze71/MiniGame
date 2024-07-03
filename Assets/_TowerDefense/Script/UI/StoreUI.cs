using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace V.TowerDefense
{
    public class StoreUI : MonoBehaviour
    {
        [SerializeField] private Button coinBTN;

        private void Awake()
        {
            coinBTN.onClick.AddListener(() =>
            {
                GameEventManager.I.IncreaseMoney(1);
            });
        }
    }
}
