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
        [SerializeField] private BoxCheck _groundCheck;
        [SerializeField] private LayerMask _hitLayer;
        [SerializeField] private float _moveSpeed;

        protected Rigidbody2D _rb;
        public EMoveDirection _eMoveDir{get; protected set;}
        protected Vector2 _moveDir;
        protected Vector2 _hitBoxOffest = Vector2.zero;

        // attack
        private Timer _attackTimer;
        private bool _canAttack = true;

        [SerializeField] private float _disableTImer = .25f;
        private Coroutine _disableMoveCoroutine;
        [SerializeField] private bool _canMove = true;



        [SerializeField] private KnockBack knockBack;

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
            HitDetect();

            if(!IsGrounded())   return;
            if(!_canMove)   return;
            
            _rb.velocity = _moveDir * _moveSpeed;
        }

        private void Update() 
        {
            _attackTimer.Tick();

            SetHitBox(_eMoveDir);
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
            hitUnitColl = Physics2D.OverlapBox(_hitBoxOffest, _hitRangeConfig.HitBox.size, 0f, _hitLayer);
            if(hitUnitColl != null)
            {
                HitDamagableCollEvent?.Invoke(hitUnitColl, _soilderConfig.Attack);
                // knockBack.StartKnockBack(_eMoveDir);
                
                _canAttack = false;
                _attackTimer.StartTimer();
            }   
        }

        private void AttackTimer_OnTimerDone()
        {
            _canAttack = true;
        }
        private void OnDrawGizmos() 
        {
            if(_hitRangeConfig == null)   return;

            Gizmos.color = Color.red;

            Gizmos.DrawWireCube(_hitBoxOffest, _hitRangeConfig.HitBox.size);
        }
        #endregion

        #region Check
        public bool IsGrounded()
        {
            return _groundCheck.GetComponent<ICheck>().Check();
        }
        #endregion

        public void StartDisableMove()
        {
            if(_disableMoveCoroutine != null)
            {
                StopCoroutine(_disableMoveCoroutine);
            }
            StartCoroutine(Coroutine_DisableMovement());
        }
        private IEnumerator Coroutine_DisableMovement()
        {
            _canMove = false;
            yield return new WaitForSeconds(_disableTImer);
            _canMove = true;
        }


        private void HealthSystem_HealthChangedEvent()
        {
            Debug.Log(gameObject.name + HealthSystem.GetHealthAmount());
            if(HealthSystem.GetHealthAmount() <= 0)
            {
                StartCoroutine(Coroutine_DisableGO());
            }

        }
        
        private IEnumerator Coroutine_DisableGO()
        {
            yield return new WaitForEndOfFrame();
            gameObject.SetActive(false);
        }
    }
}
