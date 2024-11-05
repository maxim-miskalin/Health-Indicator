using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _minRandomValue = 10f;
    [SerializeField] private float _maxRandomValue = 100f;

    public void DoDamage()
    {
        float value = Random.Range(_minRandomValue, _maxRandomValue);

        _health.TakeDamage(value);
    }
}
