using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "New Character Data")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _pointValue;

    public string Name { get => _name; }
    public Sprite Icon { get => _icon; }
    public int PointValue { get => _pointValue; }
}
