using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private LevelContainer[] _allLevels;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name, _description, _difficulty;

    private int _activeLevelIndex;

    private LevelContainer ActiveLevel { get => _allLevels[_activeLevelIndex]; }

    public void CycleLevelsPositive()
    {
        CloseActiveLevel();

        if (_activeLevelIndex == _allLevels.Length - 1)
        {
            _activeLevelIndex = 0;
        }
        else
        {
            _activeLevelIndex++;
        }

        ReadActiveLevel();
    }

    public void CycleLevelNegative()
    {
        CloseActiveLevel();

        if (_activeLevelIndex == 0)
        {
            _activeLevelIndex = _allLevels.Length - 1;
        }
        else
        {
            _activeLevelIndex--;
        }

        ReadActiveLevel();
    }

    public void ReadActiveLevel()
    {
        ActiveLevel.Camera.gameObject.SetActive(true);
        _name.text = ActiveLevel.LevelName;
        _description.text = ActiveLevel.Description;
        _icon.sprite = ActiveLevel.Icon;
        _difficulty.text = ActiveLevel.Difficulty.ToString();
    }

    public void CloseActiveLevel()
    {
        ActiveLevel.Camera.gameObject.SetActive(false);
    }

    
}
