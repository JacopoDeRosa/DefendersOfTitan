using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave 
{
    [SerializeField] private string _waveName;
    [SerializeField] private CharacterSpawner[] _spawners;
    
    private List<Character> _activeCharacters;

    public string WaveName { get => _waveName; }

    public event System.Action onWaveEnd;

    public void StartWave()
    {
        _activeCharacters = new List<Character>();

        foreach (CharacterSpawner spawner in _spawners)
        {
            spawner.onCharacterSpawn += OnCharacterSpawn;
            spawner.StartSpawning();
        }
    }

    private void OnCharacterSpawn(Character character)
    {
        _activeCharacters.Add(character);
        character.onDeath += OnCharacterDeath;
    }

    private void OnCharacterDeath(Character character)
    {
        _activeCharacters.Remove(character);
        if(_activeCharacters.Count == 0)
        {
            onWaveEnd?.Invoke();
            Debug.Log("Wave " + _waveName + " Over");
        }
    }

    public CharacterSpawn[] GetAllSpawns()
    {
        CharacterSpawn[] spawns = new CharacterSpawn[_spawners.Length];

        for (int i = 0; i < _spawners.Length; i++)
        {
            spawns[i] = new CharacterSpawn(_spawners[i].Template, _spawners[i].Amount);
        }

        return spawns;
    }
}