using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _maxValue;
    [SerializeField] private float _currentValue;

    public event Action<float, float> OnValueChanged;

    public float MaxValue => _maxValue;
    public float CurrentValue => _currentValue;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    private void Start()
    {
        OnValueChanged?.Invoke(_currentValue, _maxValue);
    }

    public void TakeDamage(float damage)
    {
        if (damage <= _currentValue)
            _currentValue -= damage;
        else
            _currentValue = 0;

        OnValueChanged?.Invoke(_currentValue, _maxValue);
    }

    public void TakeDamage(int damage)
    {
        TakeDamage((float)damage);
    }

    public void Restore(float value)
    {
        _currentValue += value;

        if (_currentValue > _maxValue)
            _currentValue = _maxValue;

        OnValueChanged?.Invoke(_currentValue, _maxValue);
    }

    public void Restore(int value)
    {
        Restore((float)value);
    }
}
