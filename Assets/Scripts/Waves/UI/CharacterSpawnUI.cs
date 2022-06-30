using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSpawnUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;


    public void Init(Sprite sprite, int amount)
    {
        _image.sprite = sprite;
        _text.text = "x" + amount.ToString();
    }
}
