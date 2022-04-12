using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _step;

    private Coroutine _coroutine;

    public float CurrentHealth { get;private set; }

    public float Health => _health;

    public event UnityAction<float,float> HealthChanged;

    private void Start()
    {
        CurrentHealth = _health;
    }

    public void ApplyDamage(float damage)
    {
        TurnOn(damage);
    }

    public void Heal(float Heal)
    {
        TurnOn(Heal);
    }

    private IEnumerator ChangingHealth(float number)
    {
        var waitHalthSecond = new WaitForSeconds(0.5f);
        
        for (int i = 0; i < number / _step; i++)
        {
            CurrentHealth = Mathf.MoveTowards(CurrentHealth, CurrentHealth + number, _step);
            yield return waitHalthSecond;
        }
    }

    public void TurnOn(float number)
    {
        _coroutine = StartCoroutine(ChangingHealth(number));
        HealthChanged?.Invoke(CurrentHealth, _health);
        
    }

    public void TurnOff()
    {
        StopCoroutine(_coroutine);
    }
}
