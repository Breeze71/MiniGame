using System;
using System.Collections;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Transform BarPosition;

    public void SetBarUI(float healthPercentage)
    {
        BarPosition.transform.localScale = new Vector3(healthPercentage, 1, 1);
    }
}
