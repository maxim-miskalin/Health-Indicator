using UnityEngine;

public class Restore : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _minRandomValue = 10f;
    [SerializeField] private float _maxRandomValue = 100f;

    public void AddHealth()
    {
        float value = Random.Range(_minRandomValue, _maxRandomValue);

        _health.Restore(value);
    }
}
