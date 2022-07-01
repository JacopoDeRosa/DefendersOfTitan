using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerAudio : MonoBehaviour
{
    [SerializeField] private WaveManager _waveManger;
    [SerializeField] private AudioClip[] _startSirens;
    [SerializeField] private AudioSource _audioSource;
    private void Awake()
    {
        _waveManger.onWaveStarted += OnWaveStart;
    }

    private void OnWaveStart(Wave wave)
    {
        _audioSource.PlayOneShot(_startSirens[Random.Range(0, _startSirens.Length)]);
    }
}
