
using UnityEngine;

namespace V.TowerDefense
{
    public class Soldier : UnitBase
    {        
        protected override void Start()
        {
            _eMoveDir = EMoveDirection.Right;

            _moveDir = new Vector2((float)_eMoveDir, _rb.velocity.y).normalized;

            base.Start();
        }
    }
}
