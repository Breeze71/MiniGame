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
        public event Action<Collider2D, int> HitDamagableCollEvent;

        public HealthSystem HealthSystem {get; private set;}
        [field : SerializeField] public EMoveDirection _eMoveDir{get; protected set;}

        [Expandable][SerializeField] protected HitRangeSO _hitRangeConfig;
        [Expandable] [SerializeField] protected UnitSO _unitConfig;
        [SerializeField] private BoxCheck _groundCheck;
        [SerializeField] private float _moveSpeed;

        protected Rigidbody2D _rb;
        protected Vector2 _moveDir;
        protected Vector2 _hitBoxOffest = Vector2.zero;

        // attack
        protected Timer _attackCDTimer;
        protected bool _canAttack = true;

        [SerializeField] private float _disableMoveTimer = .25f;
        private Coroutine _disableMoveCoroutine;
        [SerializeField] protected bool _canMove = true;


        #region LC
        private void Awake() 
        {
            _rb = GetComponent<Rigidbody2D>();

            HealthSystem = new HealthSystem(_unitConfig.Health);
            _attackCDTimer = new Timer(_unitConfig.AttackTimerMax);
        }

        private void OnEnable() 
        {
            _attackCDTimer.OnTimerDone += AttackTimer_OnTimerDone;
            HealthSystem.HealthChangedEvent += HealthSystem_HealthChangedEvent;
        }

        protected virtual void Start()
        {
            _moveDir = new Vector2((float)_eMoveDir, _rb.velocity.y).normalized;
        }

        private void FixedUpdate() 
        {            
            if(!IsGrounded())   return;
            if(!_canMove)   return;
            
            _rb.velocity = _moveDir * _moveSpeed;
        }

        protected virtual void Update() 
        {
            _attackCDTimer.Tick();
        }

        private void OnDisable() 
        {
            _attackCDTimer.OnTimerDone -= AttackTimer_OnTimerDone;
            HealthSystem.HealthChangedEvent -= HealthSystem_HealthChangedEvent;
            
            HealthSystem.ResetHealth();
        }
        #endregion

        private void AttackTimer_OnTimerDone()
        {
            _canAttack = true;
        }

        protected void OnHitDamagableColl(Collider2D hitUnitColl, int damage)
        {
            HitDamagableCollEvent?.Invoke(hitUnitColl, damage);
        }

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
            yield return new WaitForSeconds(_disableMoveTimer);
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

        public void Spawn(Transform parent)
        {
            Instantiate(this, parent);
        }

        // test
        [Button]
        public void TestHit()
        {
            HitDamagableCollEvent?.Invoke(gameObject.GetComponent<Collider2D>(), 15);
        }
        
    }
}
