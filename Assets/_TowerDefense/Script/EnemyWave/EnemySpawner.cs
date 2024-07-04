using System;
using System.Collections;
using UnityEngine;

namespace V.TowerDefense
{
    public class EnemySpawner : MonoBehaviour
    {        
        [SerializeField] private Transform spawnPoint;

        [SerializeField] private Wave[] waveList;

        private EWaveState _eWaveState;
        [SerializeField] [NaughtyAttributes.ReadOnly] private int currentWaveIndex;
        private float waveCountDown;
        [SerializeField] private bool isTesting;
        private bool _isPause = false;

        private void OnEnable() 
        {
            GameEventManager.I.GameStateEvent.OnStateChange += GameStateEvent_OnStateChange;
        }
        
        private void OnDisable() 
        {
            GameEventManager.I.GameStateEvent.OnStateChange -= GameStateEvent_OnStateChange;
        }

        private void Start() 
        {
            _eWaveState = EWaveState.Idle;   
            _eWaveState = EWaveState.Start; 
        }

        private void Update()
        {
            if(_isPause)    return;

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

                ResetWave();
            }
        }

        private void ResetWave()
        {
            if(isTesting)
            {
                currentWaveIndex = 0;
                _eWaveState = EWaveState.Start;
            }
        }

        private void GameStateEvent_OnStateChange(EGameState state)
        {
            if(state == EGameState.Pause)
            {
                _isPause = true;
                waveList[currentWaveIndex].isPause = true;
            }
            else if(state == EGameState.Resume || state == EGameState.None)
            {
                _isPause = false;
                waveList[currentWaveIndex].isPause = false;
            }
        }
    }
    
    [Serializable]
    public class Wave
    {
        public float timeToNextWave;
        public bool isPause {private get; set;} = false;

        [SerializeField] private float timeToNextEnemy;
        [SerializeField] private UnitBase[] enemyList;

        public IEnumerator Coroutine_SpawnEnemies(Transform _spawnPos)
        {
            foreach(UnitBase enemy in enemyList)
            {
                enemy.Spawn(_spawnPos);
                
                yield return new WaitUntil(() => !isPause);
                yield return new WaitForSeconds(timeToNextEnemy);
            }
        }
    }
}
