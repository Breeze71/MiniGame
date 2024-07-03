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

        [field : SerializeField] public int Attack {get; set;} = 15;
        [field : SerializeField] public int Health {get; set;} = 100; 
        [field : SerializeField] public float AttackTimerMax {get; set;} = .25f;
        [field : SerializeField] public LayerMask DamagableLayer{get; private set;}

        [field : SerializeField] public int Cost {get; private set;} = 5;
    }
}
