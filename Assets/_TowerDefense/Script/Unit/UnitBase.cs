using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using NaughtyAttributes;
using UnityEngine;
using Timer = V.Utilities.Timer;

namespace V.TowerDefense
{
    public abstract class UnitBase : MonoBehaviour
    {
        public HealthSystem HealthSystem {get; private set;}

        public event Action<Collider2D, int> HitDamagableCollEvent;

        [SerializeField] private int _healthMax;
        [Expandable][SerializeField] protected HitRangeSO _hitRangeConfig;
        [Expandable] [SerializeField] private SoilderSO _soilderConfig;
        [SerializeField] private LayerMask hitLayer;

        protected Rigidbody2D _rb;
        protected EMoveDirection _eMoveDir;
        protected Vector2 _moveDir;
        protected Vector2 _hitBoxOffest;

        // attack
        private Timer _attackTimer;
        private bool _canAttack = true;

        #region LC
        private void Awake() 
        {
            _rb = GetComponent<Rigidbody2D>();

            HealthSystem = new HealthSystem(_healthMax);
            _attackTimer = new Timer(_soilderConfig.AttackTimerMax);
        }

        private void OnEnable() 
        {
            _attackTimer.OnTimerDone += AttackTimer_OnTimerDone;
            HealthSystem.HealthChangedEvent += HealthSystem_HealthChangedEvent;
        }

        protected virtual void Start() 
        {
            SetHitBox(_eMoveDir);
        }

        private void FixedUpdate() 
        {
            _rb.velocity = _moveDir;
        }

        private void Update() 
        {
            _attackTimer.Tick();

            SetHitBox(_eMoveDir);
            HitDetect();
        }

        private void OnDisable() 
        {
            _attackTimer.OnTimerDone -= AttackTimer_OnTimerDone;
            HealthSystem.HealthChangedEvent -= HealthSystem_HealthChangedEvent;
            
            HealthSystem.ResetHealth();
        }
        #endregion

        #region Hit Detect
        // Set up hit box from hit range so
        private void SetHitBox(EMoveDirection eMoveDirection)
        {
            _hitBoxOffest.Set(transform.position.x + _hitRangeConfig.HitBox.center.x * (float)eMoveDirection, 
                transform.position.y + _hitRangeConfig.HitBox.center.y);
        }
        
        private void HitDetect()
        {
            if(!_canAttack) return;

            Collider2D hitUnitColl;
            hitUnitColl = Physics2D.OverlapBox(_hitBoxOffest, _hitRangeConfig.HitBox.size, 0f, hitLayer);
            if(hitUnitColl != null)
            {
                HitDamagableCollEvent?.Invoke(hitUnitColl, _soilderConfig.Attack);
                
                _canAttack = false;
                _attackTimer.StartTimer();
            }   
        }

        private void AttackTimer_OnTimerDone()
        {
            _canAttack = true;
        }

        private void OnDrawGizmosSelected() 
        {
            if(_hitRangeConfig == null)   return;

            Gizmos.color = Color.red;

            Vector2 newCenter = new Vector2(transform.position.x + _hitRangeConfig.HitBox.center.x * (float)_eMoveDir, 
                transform.position.y + _hitRangeConfig.HitBox.center.y);

            Gizmos.DrawWireCube(newCenter, _hitRangeConfig.HitBox.size);
        }
        #endregion
    
        private void HealthSystem_HealthChangedEvent()
        {
            if(HealthSystem.GetHealthAmount() == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
