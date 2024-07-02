using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace V.TowerDefense
{
    public class KnockBack : MonoBehaviour
    {
        [SerializeField] private float _knockBackTime;
        [SerializeField] private float _knockBackForce;
        [SerializeField] private Vector2 _knockDir;
        [SerializeField] private EMoveDirection eMoveDirection = EMoveDirection.None;

        private float _timer = 0f;
        private bool _isKnockingBack;
        private Rigidbody2D _rb;
        // private 
        private void Awake() 
        {
            _rb = GetComponent<Rigidbody2D>();    
        }
        
        private void Update() 
        {
            if(_isKnockingBack)
            {
                _timer += Time.deltaTime;

                if(_timer > _knockBackTime)
                {
                    _rb.velocity = new Vector2(0f, _rb.velocity.y);
                    // _rb.angularVelocity = 0f;
                    _isKnockingBack = false;
                }
            }
        }
        
        public void StartKnockBack(EMoveDirection _eMoveDir)
        {
            Vector2 knockDir = new Vector2(_knockDir.x * - (int)_eMoveDir, _knockDir.y).normalized;
            _rb.AddForce(knockDir * _knockBackForce, ForceMode2D.Impulse);

            _timer = 0f;
            _isKnockingBack = true;

            Debug.Log(gameObject.name + "start knock back" + knockDir * _knockBackForce);
        }

        [Button]
        public void TestKnock()
        {
            StartKnockBack(eMoveDirection);
        }
    }
}
