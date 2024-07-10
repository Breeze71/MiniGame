using System;
using System.Collections;
using System.Dynamic;
using NaughtyAttributes;
using UnityEngine;
using Timer = V.Utilities.Timer;


namespace V.TowerDefense
{
    public abstract class UnitBase : MonoBehaviour, IDamagable
    {
        public event Action<Collider2D, int> OnHitDamagableCollEvent;
        public event Action OnHitEvent;
        [field : SerializeField] public EMoveDirection _eMoveDir{get; protected set;}

        public HealthSystem HealthSystem { get; set; }

        [Expandable] [SerializeField] protected UnitSO _unitConfig;

        [Expandable][SerializeField] protected HitRangeSO _hitRangeConfig;
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
        protected bool _isPause = false;

        [SerializeField] private SpriteRenderer _sprite;


        #region LC
        protected virtual void Awake() 
        {
            _rb = GetComponent<Rigidbody2D>();

            HealthSystem = new HealthSystem(_unitConfig.CurrentHealth);
            _attackCDTimer = new Timer(_unitConfig.AttackTimerMax);
        }

        private void OnEnable() 
        {
            _attackCDTimer.OnTimerDone += AttackTimer_OnTimerDone;
            HealthSystem.HealthChangedEvent += HealthSystem_HealthChangedEvent;
            GameEventManager.I.GameStateEvent.OnStateChange += GameStateEvent_OnStateChange;
        }

        protected virtual void Start()
        {
            _moveDir = new Vector2((float)_eMoveDir, _rb.velocity.y).normalized;
            _sprite.sprite = _unitConfig.Img;
        }

        private void FixedUpdate() 
        {            
            if(!IsGrounded())   return;
            if(!_canMove)   return;
            if(_isPause)    return;
            
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
            GameEventManager.I.GameStateEvent.OnStateChange -= GameStateEvent_OnStateChange;
            
            if(_disableMoveCoroutine != null)
            {
                StopCoroutine(_disableMoveCoroutine);
            }
            
            HealthSystem.ResetHealth();
        }
        #endregion

        private void AttackTimer_OnTimerDone()
        {
            _canAttack = true;
        }

        protected void OnHitDamagableColl(Collider2D hitUnitColl, int damage)
        {
            OnHitDamagableCollEvent?.Invoke(hitUnitColl, damage);
        }
        public void TakeDamage(int amount)
        {
            OnHitEvent?.Invoke();
            HealthSystem.TakeDamage(amount);
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
            _disableMoveCoroutine = StartCoroutine(Coroutine_DisableMovement());
        }
        private IEnumerator Coroutine_DisableMovement()
        {
            _canMove = false;
            yield return new WaitForSeconds(_disableMoveTimer);
            _canMove = true;
        }

        private void HealthSystem_HealthChangedEvent()
        {
            if(HealthSystem.GetHealthAmount() <= 0)
            {
                StartCoroutine(Coroutine_DisableGO());
            }
        }
        private IEnumerator Coroutine_DisableGO()
        {
            if(_eMoveDir == EMoveDirection.Left)
            {
                GameEventManager.I.CoinEvent.IncreaseMoney(_unitConfig.CurrentLevel);
            }

            yield return new WaitForEndOfFrame();
            gameObject.SetActive(false);
        }

        public void Spawn(Transform parent)
        {
            Instantiate(this, parent);
        }

        private void GameStateEvent_OnStateChange(EGameState state)
        {
            if(state == EGameState.Pause)
            {
                _isPause = true;
            }
            else if(state == EGameState.Resume || state == EGameState.None)
            {
                _isPause = false;
            }
        }

        // test
        [Button]
        public void TestHit()
        {
            OnHitDamagableCollEvent?.Invoke(gameObject.GetComponent<Collider2D>(), 15);
        }
    }
}
