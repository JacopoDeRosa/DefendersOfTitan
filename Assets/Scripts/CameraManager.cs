using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject _editingCamera;
    [SerializeField] private WaveManager _waveManager;

    private void Awake()
    {
        _waveManager.onWaveStarted += OnWaveStarted;
        _waveManager.onWaveEnded += OnWaveEnded;
    }

    private void OnWaveStarted(Wave wave)
    {
        _editingCamera.SetActive(false);
    }

    private void OnWaveEnded()
    {
        _editingCamera.SetActive(true);
    }
}
