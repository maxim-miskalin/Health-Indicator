using System.Collections;
using UnityEngine;

public class HealthBarSmoothSlider : HealthBarSlider
{
    [Header("Smooth change")]
    [SerializeField] private float _speedSmoothness = 2f;
    [SerializeField] private float _delay = 0.01f;

    private WaitForSeconds _wait;
    private Coroutine _coroutine;

    private void Start()
    {
        _wait = new(_delay);
    }

    protected override void ChangeValue(float current, float max)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        base.SetColorIndicator(current, max);
        _coroutine = StartCoroutine(MoveSmoothSlider());
    }

    private IEnumerator MoveSmoothSlider()
    {
        while (Slider.value != Ratio)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, Ratio, _speedSmoothness * Time.deltaTime);

            yield return _wait;
        }
    }
}
