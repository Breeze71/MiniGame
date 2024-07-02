using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace V.TowerDefense
{
    [CreateAssetMenu(fileName = "Hit Range Config", menuName = "Tower Defense / Hit Range Config")]
    public class HitRangeSO : ScriptableObject
    {
        [SerializeField] private EDetectType _eDetectType;

        [ShowIf("_eDetectType", EDetectType.CloseRange)]
        public Rect HitBox;

        [ShowIf("_eDetectType", EDetectType.FarRange)]
        public float Range;
    }

    public enum EDetectType
    {
        CloseRange,
        FarRange,
    }
}
