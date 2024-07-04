
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
            // HandleDamagableInRange();
            HitDetect();
        }

        // Set up hit box from hit range so
        private void SetHitBox(EMoveDirection eMoveDirection)
        {
            _hitBoxOffest.Set(transform.position.x + _hitRangeConfig.HitBox.center.x * (float)eMoveDirection, 
                transform.position.y + _hitRangeConfig.HitBox.center.y);
        }
        
        // private void HandleDamagableInRange()
        // {
        //     Vector3 faceDir = new Vector3((int)_eMoveDir, 0f, 0f);

        //     if(Physics2D.Raycast(transform.position, faceDir, _hitRangeConfig.HitBox.center.x / 2, _unitConfig.DamagableLayer))
        //     {
        //         _canMove = false;
        //         _canAttack = false;

        //         HitDetect();
        //         _attackCDTimer.StartTimer();
        //     }
        //     else
        //     {
        //         _canMove = true;
        //     }            
        // }

        private void HitDetect()
        {
            if(!_canAttack) return;
            if(_isPause)    return;
            
            Collider2D hitUnitColl;
            hitUnitColl = Physics2D.OverlapBox(_hitBoxOffest, _hitRangeConfig.HitBox.size, 0f, _unitConfig.DamagableLayer);
            if(hitUnitColl != null)
            {
                OnHitDamagableColl(hitUnitColl, _unitConfig.CurrentAttack);
            
                StartDisableMove();
                _canAttack = false;
                _attackCDTimer.StartTimer();
            }
        }

        private void OnDrawGizmos() 
        {
            if(_hitRangeConfig == null)   return;

            Gizmos.color = Color.cyan;
            Vector3 start = transform.position;
            Vector3 end = new Vector3(start.x + .5f, start.y, 0f);
            Gizmos.DrawLine(start,  end);

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_hitBoxOffest, _hitRangeConfig.HitBox.size);
        }
    }
}