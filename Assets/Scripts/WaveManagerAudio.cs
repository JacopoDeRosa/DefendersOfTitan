using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerAudio : MonoBehaviour
{
    [SerializeField] private WaveManager _waveManger;
    [SerializeField] private AudioClip[] _startSirens;
    private void Awake()
    {
        _waveManger.onWaveStarted += OnWaveStart;
    }

    private void OnWaveStart(Wave wave)
    {
        AudioSource.PlayClipAtPoint(_startSirens[Random.Range(0, _startSirens.Length -1)], Camera.main.transform.position);
    }
}
