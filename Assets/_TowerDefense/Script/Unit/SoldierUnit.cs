
using System;
using UnityEngine;

namespace V.TowerDefense
{
    public class SoldierUnit : UnitBase
    {                
        protected override void Update() 
        {
            base.Update();

            SetHitBox(_eMoveDir);
            HitDetect();
        }

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
            hitUnitColl = Physics2D.OverlapBox(_hitBoxOffest, _hitRangeConfig.HitBox.size, 0f, _unitConfig.DamagableLayer);
            if(hitUnitColl != null)
            {
                OnHitDamagableColl(hitUnitColl, _unitConfig.Attack);
                
                _canAttack = false;
                _attackTimer.StartTimer();
            }   
        }

        private void OnDrawGizmos() 
        {
            if(_hitRangeConfig == null)   return;

            Gizmos.color = Color.red;

            Gizmos.DrawWireCube(_hitBoxOffest, _hitRangeConfig.HitBox.size);
        }
    }
}