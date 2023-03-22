using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hero : MonoBehaviour
{
    [SerializeField] private UnityEvent _dead;
    [SerializeField] private UnityEvent _healthChanged;

    private float _deltaHealth;
    private bool isAlive = true;

    public float MaxHealth { get; private set; }
    public float Health { get; private set; }

    private void Start()
    {
        MaxHealth = 100f;
        Health = MaxHealth;
        _deltaHealth = 10f;
    }

    public void ChangeHealth(bool isIncrease)
    {
        if (isAlive)
        {
            if (isIncrease)
                Health += _deltaHealth;
            else
                Health -= _deltaHealth;

            if (Health > MaxHealth)
                Health = MaxHealth;

            if (Health <= 0)
            {
                Health = 0;
                isAlive = false;
                _dead.Invoke();
            }

            _healthChanged.Invoke();
        }
    }
}
