using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarSlider : HealthBar
{
    [SerializeField] private string _backgroundName = "Background";
    [SerializeField] private string _fillName = "Fill Area/Fill";

    protected Slider _slider;
    protected Image _background;
    protected Image _fill;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _background = _slider.transform.Find(_backgroundName).GetComponent<Image>();
        _fill = _slider.transform.Find(_fillName).GetComponent<Image>();
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

        _slider.value = _ratio;
    }

    protected void ChangeColor(Color color)
    {
        _background.color = color;
        _fill.color = color;
    }
}
