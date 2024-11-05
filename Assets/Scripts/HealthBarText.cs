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
        base.SetColorIndicator(current, max);
        _text.text = Math.Round(current) + "/" + Math.Round(max);
    }

    protected override void ChangeColor(Color color)
    {
        _text.color = color;
    }
}
