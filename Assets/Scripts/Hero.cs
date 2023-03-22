using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hero : MonoBehaviour
{
    [SerializeField] private UnityEvent _dead;
    [SerializeField] private UnityEvent _healthChanged;

    private bool isAlive = true;

    public float MaxHealth { get; private set; }
    public float Health { get; private set; }

    private void Start()
    {
        MaxHealth = 100f;
        Health = MaxHealth;
    }

    public void TakeDamage(float deltaHealth)
    {
        if (isAlive)
        {
            Health -= deltaHealth;

            if (Health <= 0)
            {
                Health = 0;
                isAlive = false;
                _dead.Invoke();
            }

            _healthChanged.Invoke();
        }
    }

    public void TakeHill(float deltaHealth)
    {
        if (isAlive)
        {
            Health += deltaHealth;

            if (Health > MaxHealth)
                Health = MaxHealth;

            _healthChanged.Invoke();
        }
    }
}
