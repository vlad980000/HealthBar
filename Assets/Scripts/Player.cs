using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _currentHealth;

    

    public event UnityAction<float,float> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void ApplyDamage(float damage)
    {
        if (_currentHealth >= damage)
        {
            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth,_health);
        }
        else
        {
            Debug.Log("Здоровья слишком мало, сначала нужно вылечить пациента");
        }
    }

    public void CureHealth(float damage)
    {
        if(_currentHealth + damage <= _health)
        {
            _currentHealth += damage;
            HealthChanged?.Invoke(_currentHealth, _health);
        }
        else
        {
            Debug.Log("Здоровья будет слишком много, сначала нужно покалечить пациента");
        }
    }
}
