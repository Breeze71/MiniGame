using NaughtyAttributes;
using UnityEngine;

namespace V.TowerDefense
{
    [CreateAssetMenu(fileName = "Unit Wave Config", menuName = "Tower Defense / Unit Wave Config")]
    public class UnitWaveSO : ScriptableObject
    {
        public Wave[] Waves;

        public bool IsCycle = false;

        [ReadOnly] public Wave[] CurrentWaves;

        public void SetupWave()
        {
            CurrentWaves = Waves;
        }
    }
}
