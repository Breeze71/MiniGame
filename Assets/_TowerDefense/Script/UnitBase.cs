using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class UnitBase : MonoBehaviour
    {
        public HealthSystem HealthSystem {get; private set;}

        [SerializeField] private EUnitType _unitType;
        [SerializeField] private int _healthMax;

        private Rigidbody2D _rb;
        private Vector2 moveDir;

        #region LC
        private void Awake() 
        {
            _rb = GetComponent<Rigidbody2D>();

            HealthSystem = new HealthSystem(_healthMax);    
        }

        private void Start() 
        {
            if(_unitType == EUnitType.Player)
            {
                moveDir = new Vector2(1f, _rb.velocity.y);
            }
            else if(_unitType == EUnitType.Enemy)
            {
                moveDir = new Vector2(- 1f, _rb.velocity.y);
            }
        }

        private void FixedUpdate() 
        {
            _rb.velocity = moveDir;
        }

        private void Update() 
        {
        }

        private void OnDisable() 
        {
            HealthSystem.ResetHealth();
        }
        #endregion
    }
}
