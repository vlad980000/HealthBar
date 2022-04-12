using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _step;
    [SerializeField] private float _damage;

    private Coroutine _coroutine;

    public float CurrentHealth { get;private set; }

    public float Health => _health;

    public event UnityAction<float,float> HealthChanged;

    private void Start()
    {
        CurrentHealth = _health;
    }

    private void HealthChanger()
    {
        TurnOn();
    }

    private IEnumerator ChangingHealth()
    {
        var waitHalthSecond = new WaitForSeconds(0.5f);

        for (int i = 0; i < _damage / _step; i++)
        {
            CurrentHealth = Mathf.MoveTowards(CurrentHealth, CurrentHealth + _damage, _step);
            HealthChanged?.Invoke(CurrentHealth, _health);
            yield return waitHalthSecond;
        }

        TurnOff();
    }

    public void TurnOn()
    {
        _coroutine = StartCoroutine(ChangingHealth());
    }

    public void TurnOff()
    {
        StopCoroutine(_coroutine);
    }
}
