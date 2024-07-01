using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class Enemy : UnitBase
    {
        protected override void Start()
        {
            base.Start();
            _eMoveDir = EMoveDirection.Left;

            _moveDir = new Vector2((float)_eMoveDir, _rb.velocity.y);
        }

        protected override void SetHitBox()
        {
            base.SetHitBox();

            _hitBoxOffest.Set(transform.position.x + _hitRangeConfig.HitBox.center.x * (float)_eMoveDir, 
                transform.position.y + _hitRangeConfig.HitBox.center.y);
        }
    }
}
