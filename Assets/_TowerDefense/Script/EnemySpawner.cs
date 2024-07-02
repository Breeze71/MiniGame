using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace V.TowerDefense
{
    public class EnemySpawner : MonoBehaviour
    {        
        [SerializeField] private Transform spawnPoint;

        // test
        public GameObject enemyPre;
        [Button]
        public void SpawnSoilder()
        {
            Instantiate(enemyPre, spawnPoint);
        }
    }
}
