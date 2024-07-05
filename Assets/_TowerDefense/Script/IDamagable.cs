using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public interface IDamagable
    {
        public HealthSystem HealthSystem { get; set; }

        public void TakeDamage(int amount);
    }
}
