using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterData _data;

    public CharacterData Data { get => _data; }
    public bool Targeted { get; private set; }

    public void SetTargeted(bool targeted)
    {
        Targeted = targeted;
    }
}

