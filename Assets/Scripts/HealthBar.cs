using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [Header("Color of bar value")]
    [SerializeField] protected Color _colorIndicator = Color.white;
    [SerializeField] protected float _criticalValueFraction = 0.25f;
    [SerializeField] protected Color _colorIndicatorCriticalValue = Color.red;

    protected float _ratio;

    private void OnEnable()
    {
        _health.OnValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _health.OnValueChanged -= ChangeValue;
    }

    protected abstract void ChangeValue(float current, float max);
}
