using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointKeeper : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private int _score;


    private void Awake()
    {
        foreach (CharacterSpawner spawner in FindObjectsOfType<CharacterSpawner>())
        {
            spawner.onCharacterSpawn += RegisterCharacter;
        }
    }
    private void RegisterCharacter(Character character)
    {
        character.onDeath += OnCharacterDeath;
    }

    private void OnCharacterDeath(Character character)
    {
        _score += character.Data.PointValue;
        ReDrawScore();
    }

    private void ReDrawScore()
    {
        _scoreText.text = _score.ToString().PadLeft(6, '0');
    }
}
