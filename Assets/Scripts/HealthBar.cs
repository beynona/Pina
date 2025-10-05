using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] private Health _health;
    [SerializeField] private Gradient _gradient;

    // Подписка на событие
    private void Awake()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    // Отписка от события
    // OnDestroy срабатывает при удалении объекта со сцены
    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float valueAsPercentage)
    {
        _healthBarFilling.fillAmount = valueAsPercentage;
        _healthBarFilling.color = _gradient.Evaluate(valueAsPercentage);
    }
}
