using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private Health _wallHealth;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Button _returnButton;

    private void Awake()
    {
        _wallHealth.onDeath += OnPlayerDeath;
        _returnButton.onClick.AddListener(ReturnToMainMenu);
    }

    private void OnPlayerDeath()
    {
        Time.timeScale = 0;
        _gameOverScreen.SetActive(true);
    }

    private void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
