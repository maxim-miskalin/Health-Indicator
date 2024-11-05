using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthBarText : HealthBar
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    protected override void ChangeValue(float current, float max)
    {
        _ratio = current / max;

        if (current != max)
        {
            if (_ratio > _criticalValueFraction && _text.color != _colorIndicator)
                _text.color = _colorIndicator;
            else if (_ratio <= _criticalValueFraction && _text.color != _colorIndicatorCriticalValue)
                _text.color = _colorIndicatorCriticalValue;
        }

        _text.text = Math.Round(current) + "/" + Math.Round(max);
    }
}
