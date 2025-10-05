using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [Header("Health stats")] 
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;

    // Можно подписывать методы,которые ничего не возвращают и имеют 1 параметр float
    public event Action<float> HealthChanged;

    public IntEvent Hit = new();
    
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        // Иммитация, пока нет врагов
        // if (Input.GetKeyDown(KeyCode.F))
        // {
        //     ApplyDamage(UnityEngine.Random.Range(1, 10));
        // }
    }

    public void Damaged()
    {
        Debug.Log("Damaged");
        ApplyDamage(UnityEngine.Random.Range(1, 10));
    }

    public void ApplyDamage(int value)
    {
        if (value > 0)
        {
            _currentHealth -= value;
            Hit.Invoke(value);

            if (_currentHealth <= 0)
            {
                Death();
            }
            else
            {
                float currentHealthAsPercentage = (float)_currentHealth / _maxHealth;
                HealthChanged?.Invoke(currentHealthAsPercentage);
            }
        }
        else
        {
            Debug.Log("Отрицательное значение урона");
        }
    }

    private void Death()
    {
        HealthChanged?.Invoke(0);
        Debug.Log("You are death");
    }

}
