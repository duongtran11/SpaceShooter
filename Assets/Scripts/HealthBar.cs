using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider Slider;
    private float _currentValue;
    public float CurrentValue => _currentValue;
    void Awake()
    {
        Slider = GetComponent<Slider>();
        _currentValue = Slider.value;
    }
    public void IncreaseValue(float value)
    {
        _currentValue += value;
        _currentValue = Mathf.Clamp(_currentValue, Slider.minValue, Slider.maxValue);
    }
    public void DecreaseValue(float value)
    {
        _currentValue -= value;
        _currentValue = Mathf.Clamp(_currentValue, Slider.minValue, Slider.maxValue);
        Slider.value = _currentValue;
    }
}
