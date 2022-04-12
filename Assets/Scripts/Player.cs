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
        Mathf.Clamp(CurrentHealth, 0, _health);
    }

    public void ApplyDamage(float damage)
    {
        CurrentHealth -= damage;
        HealthChanged?.Invoke(CurrentHealth, _health);
    }

    public void Heal(float damage)
    {
        CurrentHealth += damage;
        HealthChanged?.Invoke(CurrentHealth, _health);
    }
}
