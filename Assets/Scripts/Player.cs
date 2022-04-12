using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    public float CurrentHealth { get;private set; }

    public float Health => _health;

    public event UnityAction<float,float> HealthChanged;

    private void Start()
    {
        CurrentHealth = _health;
    }

    public void ApplyDamage(float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, _health - _health, _health);
        HealthChanged?.Invoke(CurrentHealth, _health);
    }

    public void Heal(float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + damage, _health - _health, _health);
        HealthChanged?.Invoke(CurrentHealth, _health);
    }
}
