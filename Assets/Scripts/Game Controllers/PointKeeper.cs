using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointKeeper : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private int _startScore;

    private int _score;


    private void Awake()
    {
        foreach (CharacterSpawner spawner in FindObjectsOfType<CharacterSpawner>())
        {
            spawner.onCharacterSpawn += RegisterCharacter;
        }
        _score += _startScore;
        ReDrawScore();
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

    public bool TrySpendPoints(int amount)
    {
        if (_score < amount) return false;

        _score -= amount;

        ReDrawScore();

        return true;
    }
}
