using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    [CreateAssetMenu(fileName = "HitBoxConfig", menuName = "SO / HitBoxConfig")]
    public class HitRangeSO : ScriptableObject
    {
        [field : SerializeField] 
        public Rect HitBox { get; private set;}
    }
}
