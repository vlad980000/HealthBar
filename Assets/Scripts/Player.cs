using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private readonly float _maxHealth = 100;
    private readonly float _minHealth = 0;
    private float _currentHealth;

    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth);
    }

    public void ApplyDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealth, _maxHealth);
        HealthChanged?.Invoke(_currentHealth);
    }

    public void Heal(float heal)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + heal, _minHealth, _maxHealth);
        HealthChanged?.Invoke(_currentHealth);
    }
}