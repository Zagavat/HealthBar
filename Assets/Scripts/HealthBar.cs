using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    private Image _healthBar;
    private Coroutine _drawInJob;

    private void Start()
    {
        _healthBar = GetComponent<Image>();
    }

    public void ChangedValue()
    {
        if (_drawInJob != null)
            StopCoroutine(_drawInJob);

        _drawInJob = StartCoroutine(DrawBar(_hero.Health / _hero.MaxHealth));
    }

    IEnumerator DrawBar(float targetValue)
    {
        float delta = 0.01f;
        float value = _healthBar.fillAmount;
        var waitForMoment = new WaitForSeconds(0.1f);

        while (value != targetValue)
        {
            value = Mathf.MoveTowards(value, targetValue, delta);
            _healthBar.fillAmount = value;
            yield return new WaitForFixedUpdate();
        }
    }
}
