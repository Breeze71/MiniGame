using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class HitPresenter : MonoBehaviour
    {
        [SerializeField] private UnitBase _unit;

        private void OnEnable() 
        {
            _unit.HitDamagableCollEvent += Unit_OnHitDamagableCollEvent;
        }

        private void Unit_OnHitDamagableCollEvent(Collider2D coll, int damageAmount)
        {
            UnitBase hitUnit;
            coll.gameObject.TryGetComponent<UnitBase>(out hitUnit);
            Debug.Log("hit");
            
            if(hitUnit != null)
            {
                hitUnit.HealthSystem.TakeDamage(damageAmount);
                Debug.Log("damage");
            }
        }

        // knock back
        // flash
        // pop up text
        // deal damage

    }
}
