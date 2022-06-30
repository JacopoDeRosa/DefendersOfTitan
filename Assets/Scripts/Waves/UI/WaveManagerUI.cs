using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManagerUI : MonoBehaviour
{
    [SerializeField] private CharacterSpawnUI[] _characterSpawnDrawers;
    [SerializeField] private Button _nextWaveButton;
    [SerializeField] private WaveManager _target;
    [SerializeField] private GameObject _nextWaveScreen;
    [SerializeField] private GameObject _victoryScreen;

    private Queue<CharacterSpawnUI> _freeSpawnUi;

    private void Awake()
    {
        ResetSpawnUI();
        _target.onWaveEnded += InitNextWaveScreen;
        _target.onWaveEnded += InitEndScreen;
    }

    private void Start()
    {
        _nextWaveButton.onClick.AddListener(StartNextWave);
        InitNextWaveScreen();
    }

    public void StartNextWave()
    {
        _nextWaveScreen.SetActive(false);
        _target.StartNextWave();
    }

    public void GetWaveEnemies(Wave wave)
    {
        ResetSpawnUI();
        foreach (var spawn in wave.GetAllSpawns())
        {
            CharacterSpawnUI ui = _freeSpawnUi.Dequeue();
            ui.gameObject.SetActive(true);
            ui.Init(spawn.Template.Data.Icon, spawn.Amount);
        }
    }

    private void ResetSpawnUI()
    {
        foreach (CharacterSpawnUI ui in _characterSpawnDrawers)
        {
            ui.gameObject.SetActive(false);
        }
        _freeSpawnUi = new Queue<CharacterSpawnUI>(_characterSpawnDrawers);
    }

    private void InitNextWaveScreen()
    {
        Wave wave = _target.GetNextWave();
        if (wave == null) return;
        _nextWaveScreen.SetActive(true);
        GetWaveEnemies(wave);
    }

    private void InitEndScreen()
    {
        if (_target.GetNextWave() != null) return;
        _victoryScreen.SetActive(true);
    }
}
