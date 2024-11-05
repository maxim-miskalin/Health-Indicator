using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarSlider : HealthBar
{
    [SerializeField] protected Image Background;
    [SerializeField] protected Image Fill;

    protected Slider Slider;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    protected override void ChangeValue(float current, float max)
    {
        base.SetColorIndicator(current, max);
        Slider.value = Ratio;
    }

    protected override void ChangeColor(Color color)
    {
        Background.color = color;
        Fill.color = color;
    }
}
