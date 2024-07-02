using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    [CreateAssetMenu(fileName = "Wave Config", menuName = "Tower Defense / Enemy Wave Config")]
    public class EnemyWaveSO : ScriptableObject
    {
        public float spawnCD;
    }
}
