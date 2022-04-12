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
        if (CurrentHealth >= damage)
        {
            CurrentHealth -= damage;
            HealthChanged?.Invoke(CurrentHealth,_health);
        }
        else
        {
            Debug.Log("Здоровья слишком мало, сначала нужно вылечить пациента");
        }
    }

    public void Heal(float damage)
    {
        if(CurrentHealth + damage <= _health)
        {
            CurrentHealth += damage;
            HealthChanged?.Invoke(CurrentHealth, _health);
        }
        else
        {
            Debug.Log("Здоровья будет слишком много, сначала нужно покалечить пациента");
        }
    }
}
