using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public interface ICheck
    {
        public bool Check(); 
        public bool Check(int _direction, float _distance, LayerMask _checkMask);
    }
}
