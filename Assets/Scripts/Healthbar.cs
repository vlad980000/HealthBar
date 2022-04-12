using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    private void Update()
    {
        OnValueChanged(_player.CurrentHealth,_player.Health);
    }
}
