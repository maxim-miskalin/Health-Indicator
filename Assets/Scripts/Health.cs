using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _maxValue;

    public event Action<float, float> ValueChanged;

    public float MaxValue => _maxValue;
    public float CurrentValue { get; private set; }

    private void Awake()
    {
        CurrentValue = _maxValue;
    }

    private void Start()
    {
        ValueChanged?.Invoke(CurrentValue, _maxValue);
    }

    public void TakeDamage(float damage)
    {
        CurrentValue = Mathf.Clamp(CurrentValue - damage, 0, _maxValue);

        ValueChanged?.Invoke(CurrentValue, _maxValue);
    }

    public void Restore(float value)
    {
        CurrentValue = Mathf.Clamp(CurrentValue + value, 0, _maxValue);

        ValueChanged?.Invoke(CurrentValue, _maxValue);
    }
}
