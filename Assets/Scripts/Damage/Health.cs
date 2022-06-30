using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHp;

    private int _currentHp;

    private bool _dead;

    public int CurrentHp { get => _currentHp; }

    public event Action onDeath;
    public event Action<int> onHpChange;

    private void Awake()
    {
        _currentHp = _maxHp;    
    }

    public void AddToHp(int toAdd)
    {
        if (_dead) return;
        _currentHp += toAdd;
        CheckDead();
        onHpChange?.Invoke(_currentHp);
    }

    public void RemoveHp(int toRemove)
    {
        if (_dead) return;
        _currentHp -= toRemove;
        CheckDead();
        onHpChange?.Invoke(_currentHp);
    }

    private void CheckDead()
    {
        if(_currentHp <= 0 && _dead == false)
        {
            _currentHp = 0;
            _dead = true;
            onDeath?.Invoke();
            OnDeath();
        }

    }

    protected virtual void OnDeath()
    {

    }

    public void SetMaxHp(int maxHp, bool fillHp)
    {
        _maxHp = maxHp;
        if(fillHp)
        {
            _currentHp = _maxHp;
        }
    }

    public void SetMaxHp(int maxHp)
    {
        SetMaxHp(maxHp, false);
    }
}
