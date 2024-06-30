using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    [field: SerializeField] public int healthAmount {get; set; }
    [field: SerializeField]public HealthBarUI healthBarUI { get; set; }
    public HealthSystem healthSystem { get; set; }

    private void Start() 
    {
        healthSystem = new HealthSystem(healthAmount);

        SetupHealthSystemUI();
    }

    public void TakeDamage(int _damageAmount)
    {
        healthSystem.TakeDamage(_damageAmount);

        if(healthSystem.GetHealthAmount() == 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void SetupHealthSystemUI()
    {
        healthBarUI.SetupHealthSystemUI(healthSystem);
    }
    public Transform GetTransform()
    {
        return transform;
    }

}
