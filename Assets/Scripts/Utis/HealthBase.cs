using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    public Action OnKill;

    public bool destroyOnkill = false;

    public float delayOnkill = 0f;

    private int _currentLife;
    private bool _isDead = false;

    [SerializeField] private FlashColors _flashColors;


    private void Awake()
    {
        Init();

        if (_flashColors == null)
        {
            _flashColors = GetComponent<FlashColors>();
        }
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }

        if (_flashColors != null)
        {
            _flashColors.Flash();
        }
    }

    private void Kill()
    {
        _isDead = true;

        if (destroyOnkill)
        {
            Destroy(gameObject, delayOnkill);
        }
        OnKill?.Invoke();
    }
}
