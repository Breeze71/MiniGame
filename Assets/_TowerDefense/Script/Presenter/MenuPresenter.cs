using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class MenuPresenter : MonoBehaviour
    {
        [SerializeField] private MenuUI _menuUI;

        [SerializeField] private GameObject _soilderMenu;
        [SerializeField] private GameObject _upgradeMenu;
        [SerializeField] private GameObject _storeMenu;
        
        private List<GameObject> _menus = new List<GameObject>();

        #region LC
        private void Awake() 
        {
            _menus.Add(_soilderMenu);
            _menus.Add(_upgradeMenu);
            _menus.Add(_storeMenu);
        }

        private void Start() 
        {
            CloseAllMenu();    
        }

        private void OnEnable() 
        {
            _menuUI.SoiderBTNEvent += MenuUI_SoiderBTNEvent;
            _menuUI.UpgradeBTNEvent += MenuUI_UpgradeBTNEvent;
            _menuUI.StoreBTNEvent += MenuUI_StoreBTNEvent;
        }

        private void OnDisable() 
        {
            _menuUI.SoiderBTNEvent -= MenuUI_SoiderBTNEvent;
            _menuUI.UpgradeBTNEvent -= MenuUI_UpgradeBTNEvent;
            _menuUI.StoreBTNEvent -= MenuUI_StoreBTNEvent;
        }
        #endregion

        private void MenuUI_SoiderBTNEvent()
        {
            OpenSpecificMenu(_soilderMenu);
        }
        private void MenuUI_UpgradeBTNEvent()
        {
            OpenSpecificMenu(_upgradeMenu);
        }
        private void MenuUI_StoreBTNEvent()
        {
            OpenSpecificMenu(_storeMenu);
        }

        private void OpenSpecificMenu(GameObject menu)
        {
            if(menu.activeSelf)
            {
                menu.SetActive(false);
            }
            else
            {
                CloseAllMenu();
                menu.SetActive(true);
            }
        }

        private void CloseAllMenu()
        {
            foreach(GameObject menu in _menus)
            {
                menu.SetActive(false);
            }
        }

    }
}
