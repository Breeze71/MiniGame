using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class GameEventManager : MonoBehaviour
    {
        public static GameEventManager I {get; private set;}

        public CoinEvent CoinEvent {get; private set;}

        private void Awake() 
        {
            if(I != null)
            {
                Debug.LogWarning("More than One GameEventManager Singleton");
                return;
            }    

            I = this;

            CoinEvent = new CoinEvent();
        }
    }
}
