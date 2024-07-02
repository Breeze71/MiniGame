using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

        public void Spawn(Transform transform)
        {
            Instantiate(this, transform);
        }
    }
}
