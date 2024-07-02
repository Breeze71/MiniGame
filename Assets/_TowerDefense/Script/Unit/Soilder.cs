using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace V.TowerDefense
{
    public class Soilder : UnitBase
    {        
        protected override void Start()
        {
            _eMoveDir = EMoveDirection.Right;

            _moveDir = new Vector2((float)_eMoveDir, _rb.velocity.y);

            base.Start();
        }
    }
}
