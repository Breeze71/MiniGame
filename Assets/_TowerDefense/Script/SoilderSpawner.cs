using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace V.TowerDefense
{
    public class SoilderSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        public void SpawnSoilder(GameObject soilderPrefabs)
        {
            Debug.Log("spawn");
            Instantiate(soilderPrefabs, spawnPoint);
        }
    }
}
