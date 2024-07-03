using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace V.TowerDefense
{
    public class MenuBTNBase : MonoBehaviour
    {
        [Expandable] public UnitSO SoilderConfig;

        protected virtual void Start() 
        {
            
        }
    }
}
