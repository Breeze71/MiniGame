using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using V.Tool.JuicyFeeling;

namespace V.TowerDefense
{
    public class HitPresenter : MonoBehaviour
    {
        [SerializeField] private UnitBase _unit;
        [SerializeField] private FlashControl _flashControl;
        [SerializeField] private SquashAndStretch _squashAndStretch;

        private void OnEnable() 
        {
            _unit.OnHitDamagableCollEvent += Unit_OnHitDamagableCollEvent;
            _unit.OnHitEvent += Unit_OnHitEvent;
        }

        private void OnDisable() 
        {
            _unit.OnHitDamagableCollEvent -= Unit_OnHitDamagableCollEvent;
            _unit.OnHitEvent -= Unit_OnHitEvent;
        }

        private void Unit_OnHitDamagableCollEvent(Collider2D coll, int damageAmount)
        {
            // UnitBase hitUnit = coll.gameObject.GetComponent<UnitBase>();
            IDamagable damagable = coll.gameObject.GetComponent<IDamagable>();
            
            if(damagable != null)
            {
                damagable.TakeDamage(damageAmount);
            }
        }

        private void Unit_OnHitEvent()
        {
            _unit.StartDisableMove();
            _squashAndStretch.PlaySquashAndStretch();
            _flashControl.StartFlash();            
        }

        // knock back
        // flash
        // pop up text
        // deal damage

    }
}
