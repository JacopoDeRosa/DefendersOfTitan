using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Wave[] _allWaves;

    private int _currentWave = -1;

    public bool IsFinalWave { get => _currentWave == _allWaves.Length - 1; }

    public event Action onWaveEnded;

    public void StartNextWave()
    {
        if(_currentWave == _allWaves.Length - 1)
        {
            return;
        }

        _currentWave++;
        _allWaves[_currentWave].StartWave();
        _allWaves[_currentWave].onWaveEnd += OnWaveEnd;
    }

    public Wave GetNextWave()
    {
        if(_currentWave == _allWaves.Length - 1)
        {
            return null;
        }

        return _allWaves[_currentWave + 1];
    }

    private void OnWaveEnd()
    {
        onWaveEnded?.Invoke();
    }
}

