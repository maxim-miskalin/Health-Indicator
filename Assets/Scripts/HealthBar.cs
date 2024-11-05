using UnityEngine;
using UnityEngine.UIElements;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;
    [Header("Color of bar value")]
    [SerializeField] protected Color ColorIndicator = Color.white;
    [SerializeField] protected float CriticalValueFraction = 0.25f;
    [SerializeField] protected Color ColorIndicatorCriticalValue = Color.red;

    protected float Ratio;

    private void OnEnable()
    {
        Health.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        Health.ValueChanged -= ChangeValue;
    }

    protected virtual void SetColorIndicator(float current, float max)
    {
        Ratio = current / max;

        if (current != max)
        {
            if (Ratio > CriticalValueFraction)
                ChangeColor(ColorIndicator);
            else if (Ratio <= CriticalValueFraction)
                ChangeColor(ColorIndicatorCriticalValue);
        }
    }

    protected abstract void ChangeValue(float current, float max);

    protected abstract void ChangeColor(Color color);
}
