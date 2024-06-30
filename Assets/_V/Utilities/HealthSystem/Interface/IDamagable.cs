using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public int healthAmount {get; set; }
    public HealthSystem healthSystem {get; set;}
    public HealthBarUI healthBarUI{get; set;}

    public void TakeDamage(int damageAmount);
    public void SetupHealthSystemUI();
    public Transform GetTransform();
}
