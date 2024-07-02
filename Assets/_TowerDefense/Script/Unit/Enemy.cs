using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class Enemy : UnitBase
    {
        protected override void Start()
        {
            _eMoveDir = EMoveDirection.Left;

            _moveDir = new Vector2((float)_eMoveDir, _rb.velocity.y);
            
            base.Start();
        }
    }
}
