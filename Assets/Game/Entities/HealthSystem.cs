using System;
using Unity.Profiling;
using UnityEditor.MPE;
using UnityEngine;

public class HealthSystem : MonoBehaviour {
    protected int healthAmount;
    protected float healthRegenRate;

    // bool true = health increased, bool false = health decreased
    public event Action<int, bool> OnHealthChanged;
    public event Action OnDead;

    public void Setup(int healthAmount, float healthRegenRate) {
        this.healthAmount = healthAmount;
        this.healthRegenRate = healthRegenRate;
    }

    public virtual void TakeDamage(float damage) {
        healthAmount -= (int)damage;

        if (healthAmount <= 0) {
            healthAmount = 0;
            Die();
        }

        OnHealthChanged?.Invoke(healthAmount, false);
    }

    public virtual void Die() {
        OnDead?.Invoke();
    }
}