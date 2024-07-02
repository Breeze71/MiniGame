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
        [SerializeField] private KnockBack _knockBack;
        [SerializeField] private FlashControl _flashControl;
        [SerializeField] private SquashAndStretch _squashAndStretch;

        private void OnEnable() 
        {
            _unit.HitDamagableCollEvent += Unit_OnHitDamagableCollEvent;
        }

        private void OnDisable() 
        {
            _unit.HitDamagableCollEvent -= Unit_OnHitDamagableCollEvent;
        }

        private void Unit_OnHitDamagableCollEvent(Collider2D coll, int damageAmount)
        {
            UnitBase hitUnit = coll.gameObject.GetComponent<UnitBase>();
            
            if(hitUnit != null)
            {
                hitUnit.StartDisableMove();

                hitUnit.HealthSystem.TakeDamage(damageAmount);
                
                _squashAndStretch.PlaySquashAndStretch();
                _flashControl.StartFlash();
            }
        }

        // knock back
        // flash
        // pop up text
        // deal damage

    }
}
