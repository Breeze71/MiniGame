using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class ArcherUnit : UnitBase
    {
        protected override void Update() 
        {
            base.Update();

            HitDetect();
        }

        // 射程之內
        private void HitDetect()
        {
            Vector3 sightdir = new Vector3((int)_eMoveDir, 0f, 0f);

            if(Physics2D.Raycast(transform.position, sightdir, _hitRangeConfig.Range, _unitConfig.DamagableLayer))
            {
                _canMove = false;
            }
            else
            {
                _canMove = true;
            }
        }

        private void OnDrawGizmos() 
        {
            if(_hitRangeConfig == null)   return;

            Gizmos.color = Color.black;
            Vector3 start = transform.position;
            Vector3 end = new Vector3(start.x + (int)_eMoveDir * _hitRangeConfig.Range, 0f, 0f);
            
            Gizmos.DrawLine(start,  end);
        }

    }
}
