using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterData _data;
    [SerializeField] private Health _health;

    public CharacterData Data { get => _data; }
    public bool Targeted { get; private set; }

    public event CharacterHandler onDeath;

    private void Awake()
    {
        _health.onDeath += OnDeath;
    }

    public void SetTargeted(bool targeted)
    {
        Targeted = targeted;
    }

    private void OnDeath()
    {
        onDeath?.Invoke(this);
    }
}

public delegate void CharacterHandler(Character character);

