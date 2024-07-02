using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace V.TowerDefense
{
    [CreateAssetMenu(fileName = "Unit Config", menuName = "Tower Defnse / Unit Config")]
    public class UnitSO : ScriptableObject
    {
        [ShowAssetPreview]
        public GameObject soilderPrefabs;

        [field : SerializeField] public int Attack {get; private set;} = 15;
        [field : SerializeField] public int Health {get; private set;} = 100; 
        [field : SerializeField] public float AttackTimerMax {get; private set;} = .25f;
        [field : SerializeField] public LayerMask DamagableLayer;
    }
}
