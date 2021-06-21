using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject HealthBar;
    [SerializeField] GameObject HealthBarInside;
    [SerializeField] const float MaxHealth = 100;
    public float CurrentHealth;

    private void Update()
    {
        Die();
        ShowHealthBar();
        DontExceedMaxHealth();
    }
    void DontExceedMaxHealth()
    {
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
    }
    void ShowHealthBar()
    {
        if (CurrentHealth < MaxHealth)
        {
            Animate();
            HealthBar.SetActive(true);
        }
        else
        {
            HealthBar.SetActive(false);
        }
    }
    void Animate() => HealthBarInside.transform.localScale = new Vector3(CurrentHealth / 100, HealthBarInside.transform.localScale.y, HealthBarInside.transform.localScale.z);
    public virtual void Die()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            HighScoreManager.Instance.IncreaseHighScore(1);
        }
    }
}
