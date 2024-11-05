using UnityEngine;

public class HealthBarSmoothSlider : HealthBarSlider
{
    [Header("Smooth change")]
    [SerializeField] private float _speedSmoothness = 0.5f;

    private bool _isSmooth = false;

    private void Update()
    {
        if (_isSmooth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _ratio, _speedSmoothness * Time.deltaTime);

            if (_slider.value == _ratio)
                _isSmooth = false;
        }
    }

    protected override void ChangeValue(float current, float max)
    {
        _ratio = current / max;

        if (current != max)
        {
            if (_ratio > _criticalValueFraction && _background.color != _colorIndicator)
                ChangeColor(_colorIndicator);
            else if (_ratio <= _criticalValueFraction && _background.color != _colorIndicatorCriticalValue)
                ChangeColor(_colorIndicatorCriticalValue);
        }

        _isSmooth = true;
    }
}
