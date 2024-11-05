using UnityEngine;
using UnityEngine.UIElements;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [Header("Color of bar value")]
    [SerializeField] protected Color ColorIndicator = Color.white;
    [SerializeField] protected float CriticalValueFraction = 0.25f;
    [SerializeField] protected Color ColorIndicatorCriticalValue = Color.red;

    protected float Ratio;

    private void OnEnable()
    {
        Health.ValueChanged += OnChangeValue;
    }

    private void OnDisable()
    {
        Health.ValueChanged -= OnChangeValue;
    }

    protected virtual void SetColorIndicator(float current, float max)
    {
        if (Ratio > CriticalValueFraction)
            ChangeColor(ColorIndicator);
        else if (Ratio <= CriticalValueFraction)
            ChangeColor(ColorIndicatorCriticalValue);
    }

    protected abstract void OnChangeValue(float current, float max);

    protected abstract void ChangeColor(Color color);
}
