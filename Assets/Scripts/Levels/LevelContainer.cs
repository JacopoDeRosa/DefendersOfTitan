using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LevelContainer
{
    [SerializeField] [TextArea] private string _levelName;
    [SerializeField] [TextArea] private string _description;
    [SerializeField] private Difficulties _difficulty;
    [SerializeField] private Sprite _icon;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private int _sceneIndex;


    public string LevelName { get => _levelName; }
    public string Description { get => _description; }
    public Difficulties Difficulty { get => _difficulty; }
    public Sprite Icon { get => _icon; }
    public CinemachineVirtualCamera Camera { get => _camera; }
    public int Scene { get => _sceneIndex; }
}
