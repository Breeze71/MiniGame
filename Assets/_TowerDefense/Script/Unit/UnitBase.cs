using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace V.TowerDefense
{
    public abstract class UnitBase : MonoBehaviour
    {
        public HealthSystem HealthSystem {get; private set;}

        public event Action<Collider2D, int> HitDamagableCollEvent;

        [SerializeField] private int _healthMax;
        [Expandable][SerializeField] protected HitRangeSO _hitRangeConfig;
        [SerializeField] private LayerMask hitLayer;
        public int damageAmount = 30;

        protected Rigidbody2D _rb;
        protected EMoveDirection _eMoveDir;
        protected Vector2 _moveDir;
        protected Vector2 _hitBoxOffest;

        #region LC
        private void Awake() 
        {
            _rb = GetComponent<Rigidbody2D>();

            HealthSystem = new HealthSystem(_healthMax);    
            Debug.Log("awale");
        }

        protected virtual void Start() 
        {
            SetHitBox();
        }

        private void FixedUpdate() 
        {
            _rb.velocity = _moveDir;
        }

        private void Update() 
        {
            HitDetect();
        }

        private void OnDisable() 
        {
            HealthSystem.ResetHealth();
        }
        #endregion

        // Set up hit box from hit range so
        protected virtual void SetHitBox() {}

        private void HitDetect()
        {
            Collider2D hitUnitColl;
            hitUnitColl = Physics2D.OverlapBox(_hitBoxOffest, _hitRangeConfig.HitBox.size, 0f, hitLayer);
            Debug.Log(hitUnitColl);
            if(hitUnitColl != null)
            {
                HitDamagableCollEvent?.Invoke(hitUnitColl, damageAmount);
            }            
        }

        private void OnDrawGizmosSelected() 
        {
            if(_hitRangeConfig == null)   return;
            Gizmos.color = Color.red;

            Gizmos.DrawWireCube(transform.position + (Vector3)_hitRangeConfig.HitBox.center, _hitRangeConfig.HitBox.size);
        }
    }
}
