using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private WaveManager _waveManager;
    [SerializeField] private Health _wallHp;
    [SerializeField] private TMP_Text _waveCounter, _waveName, _wallHpDisplay;


    private void Awake()
    {
        _waveManager.onWaveStarted += OnWaveStarted;
        _wallHp.onHpChange += OnWallHpChange;
    }

    private void Start()
    {
        OnWallHpChange(_wallHp.CurrentHp);
        _waveCounter.text = (_waveManager.CurrentWave + 1).ToString() + "/" + _waveManager.WaveCount.ToString();
    }

    private void OnWaveStarted(Wave wave)
    {
        _waveCounter.text = (_waveManager.CurrentWave + 1).ToString() + "/" + _waveManager.WaveCount.ToString();
        _waveName.text = wave.WaveName;
    }

    public void OnWallHpChange(int hp)
    {
        _wallHpDisplay.text = "Integrity: " + hp.ToString().PadLeft(4, '0');
    }
}
