using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    public void OnValueChanged(float value, float maxValue)
    {
        Slider.value = Mathf.MoveTowards(Slider.value,value / maxValue,Time.deltaTime * 0.1f);
    }
}
