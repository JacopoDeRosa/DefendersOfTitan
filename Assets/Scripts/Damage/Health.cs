using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHp;

    private int _currentHp;

    private bool _dead;

    public event Action onDeath;

    private void Awake()
    {
        _currentHp = _maxHp;    
    }

    public void AddToHp(int toAdd)
    {
        if (_dead) return;
        _currentHp += toAdd;
        CheckDead();
    }

    public void RemoveHp(int toRemove)
    {
        if (_dead) return;
        _currentHp -= toRemove;
        CheckDead();
    }

    private void CheckDead()
    {
        if(_currentHp <= 0 && _dead == false)
        {
            _currentHp = 0;
            _dead = true;
            onDeath?.Invoke();
        }

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
