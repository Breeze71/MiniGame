using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace V.TowerDefense
{
    public class UnitSpawner : MonoBehaviour
    {        
        [SerializeField] private Transform spawnPoint;
        [Expandable][SerializeField] private UnitWaveSO _config;
        
        [SerializeField] 
        [ReadOnly] private int currentWaveIndex = 0;
        private EWaveState _eWaveState;
        private float waveCountDown;
        [ReadOnly] [SerializeField] private bool _isPause = false;

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

            _config.SetupWave();
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
            if(currentWaveIndex < _config.CurrentWaves.Length - 1 && _eWaveState == EWaveState.Start)
            {
                waveCountDown = _config.CurrentWaves[currentWaveIndex].timeToNextWave;
                StartCoroutine(_config.CurrentWaves[currentWaveIndex].Coroutine_SpawnEnemies(spawnPoint));

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
            if(_config.IsCycle)
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
                _config.CurrentWaves[currentWaveIndex].isPause = true;
            }
            else if(state == EGameState.Resume || state == EGameState.None)
            {
                _isPause = false;
                _config.CurrentWaves[currentWaveIndex].isPause = false;
            }
        }
    }
    
    [Serializable]
    public class Wave
    {
        public bool isPause;
        public float timeToNextWave;
        [SerializeField] private float timeToNextEnemy;
        [SerializeField] private UnitBase[] units;

        public IEnumerator Coroutine_SpawnEnemies(Transform _spawnPos)
        {
            foreach(UnitBase unit in units)
            {
                unit.Spawn(_spawnPos);
                
                yield return new WaitUntil(() => !isPause);
                yield return new WaitForSeconds(timeToNextEnemy);
            }
        }
    }
}
