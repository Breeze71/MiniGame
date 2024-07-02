using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace V.TowerDefense
{
    public enum EWaveState
    {
        Idle,
        Start,
        End,
    }

    public class EnemySpawner : MonoBehaviour
    {        
        [SerializeField] private Transform spawnPoint;

        [SerializeField] private Wave[] waveList;

        private EWaveState _eWaveState;
        private int currentWaveIndex;
        private float waveCountDown;

        private void Start() 
        {
            _eWaveState = EWaveState.Idle;   
            _eWaveState = EWaveState.Start; 
        }

        private void Update()
        {
            // 倒計時，呼叫 wave
            if(_eWaveState == EWaveState.Start)
            {
                waveCountDown -= Time.deltaTime;
                if(waveCountDown <= 0)
                {
                    StartWave();
                }
            }
        }

        private void StartWave()
        {
            if(currentWaveIndex < waveList.Length && _eWaveState == EWaveState.Start)
            {
                waveCountDown = waveList[currentWaveIndex].timeToNextWave;
                StartCoroutine(waveList[currentWaveIndex].Coroutine_SpawnEnemies(spawnPoint));

                currentWaveIndex++; // 下一波生成時間
            }
            else
            {
                _eWaveState = EWaveState.End;
            }
        }
    }
    
    [Serializable]
    public class Wave
    {
        public float timeToNextWave;
        [SerializeField] private float timeToNextEnemy;
        [SerializeField] private UnitBase[] enemyList;

        public IEnumerator Coroutine_SpawnEnemies(Transform _spawnPos)
        {
            foreach(UnitBase enemy in enemyList)
            {
                enemy.Spawn(_spawnPos);
                
                yield return new WaitForSeconds(timeToNextEnemy);
            }
        }
    }
}
