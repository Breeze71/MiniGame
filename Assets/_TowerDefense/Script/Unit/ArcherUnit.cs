using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace V.TowerDefense
{
    public class ArcherUnit : UnitBase
    {
        [SerializeField] private Transform _firePoint;

        private bool _isFirstShoot = true;

        private Coroutine _shootCoroutine;

        protected override void Start()
        {
            base.Start();

            _canAttack = false;
        }
        protected override void Update() 
        {
            base.Update();

            HandleDamagableInRange();
        }

        // 射程之內
        private void HandleDamagableInRange()
        {
            Vector3 endPos;
            Vector3 sightdir = new Vector2((int)_eMoveDir, 0f);
            RaycastHit2D hit2D = Physics2D.Raycast(_firePoint.position, sightdir,  _hitRangeConfig.Range, _unitConfig.DamagableLayer);
            if(hit2D)
            {
                endPos = hit2D.point;
                Shoot(_firePoint.position, endPos, hit2D);
            }
        }

        #region Shoot
        private void Shoot(Vector2 startPos, Vector3 endPos, RaycastHit2D hit2D)
        {   
            if(_isFirstShoot)
            {
                _attackCDTimer.StartTimer();
                _isFirstShoot = false;
            }

            if(_canAttack)
            {
                _canAttack = false;
                _attackCDTimer.StartTimer();
                StartDisableMove();
                StartCoroutine(Coroutine_PlayTrail(startPos, endPos, hit2D));
            }
        }

        private IEnumerator Coroutine_PlayTrail(Vector2 startPos, Vector3 endPos, RaycastHit2D hit)
        {
            TrailRenderer trail = TrailPool.I.GetTrailFromPool(startPos);
            yield return null; // avoid trails before the GameObject set
            trail.emitting = true;
      
            /// Lerp Trail Position
            float distance = Vector2.Distance(startPos, endPos);
            float remainingDistance = distance;

            while(remainingDistance > 0)
            {
                float t = Mathf.Clamp01(1 - (remainingDistance / distance));
                
                trail.transform.position = Vector3.Lerp(startPos, endPos, t); // 將位置設為該百分比
                remainingDistance -= TrailPool.I.TrailConfig.SimulationSpeed * Time.deltaTime; // 固定每幀減少

                yield return null;
            }
            trail.transform.position = endPos;

            // 視覺效果到了才 造成傷害跟彈孔
            if(hit.collider != null)
            {
                OnHitDamagableColl(hit.collider, _unitConfig.Attack);
            }

            yield return new WaitForSeconds(TrailPool.I.TrailConfig.Duration);
            yield return null;
            TrailPool.I.ReleaseTrail(trail);
        }
        #endregion

        // test
        private void OnDrawGizmos() 
        {
            if(_hitRangeConfig == null)   return;

            Gizmos.color = Color.cyan;
            Vector3 start = transform.position;
            Vector3 end = new Vector3(start.x + (int)_eMoveDir * _hitRangeConfig.Range, start.y, 0f);
            
            Gizmos.DrawLine(start,  end);
        }
        [Button]
        private void TestHandleDamagableInRange()
        {
            // _canMove = false;
            _canAttack = false;
            _attackCDTimer.StartTimer();
            _canAttack = true;

            Vector3 endPos;
            Vector3 sightdir = new Vector2((int)_eMoveDir, 0f);
            RaycastHit2D hit2D = Physics2D.Raycast(_firePoint.position, sightdir,  _hitRangeConfig.Range, _unitConfig.DamagableLayer);
            if(hit2D)
            {
                endPos = hit2D.point;
            }
            else
            {
                endPos = (Vector2)_firePoint.position + (_moveDir * TrailPool.I.TrailConfig.MissDistance);

            }
            Shoot(_firePoint.position, endPos, hit2D);
            Debug.Log("test shoot");
        }

    }
}
