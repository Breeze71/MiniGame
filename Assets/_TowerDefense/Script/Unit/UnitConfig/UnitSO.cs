using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace V.TowerDefense
{
    [CreateAssetMenu(fileName = "Unit Config", menuName = "Tower Defense / Unit Config")]
    public class UnitSO : ScriptableObject
    {
        [ShowAssetPreview]
        public GameObject SoilderPrefabs;
        [ShowAssetPreview]
        public Sprite Img;
        
        [SerializeField] private int Level = 1;
        [SerializeField] private int Attack = 15;
        [SerializeField] private int Health = 100; 
        public float AttackTimerMax = .25f;
        public LayerMask DamagableLayer;

        public int SummonCost = 5;
        public float UpgradeMultiplier = 0.1f;
        public float UpgradeMultiplierPerPurchase = .8f;

        [ReadOnly] public int CurrentLevel = 1;
        [ReadOnly] public int CurrentAttack = 15;
        [ReadOnly] public int CurrentHealth = 100;
        private void OnEnable() 
        {
            ResetUnitSO();    
        }
        public void ResetUnitSO()
        {
            CurrentLevel = Level;
            CurrentAttack = Attack;
            CurrentHealth = Health;
        }
    }
}
