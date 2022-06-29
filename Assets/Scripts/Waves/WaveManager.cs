using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Wave[] _allWaves;

    private int _currentWave = -1;

    private void Start()
    {
        StartNextWave();
    }

    private void StartNextWave()
    {
        if(_currentWave == _allWaves.Length - 1)
        {
            return;
        }

        _currentWave++;
        _allWaves[_currentWave].StartWave();
    }

    public Wave GetNextWave()
    {
        if(_currentWave == _allWaves.Length - 1)
        {
            return null;
        }

        return _allWaves[_currentWave + 1];
    }
}

