using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretIdentifier : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private TurretTypes _turretType;


    public Sprite Icon { get => _icon; }
    public TurretTypes TurretType { get => _turretType; }
}

public enum TurretTypes
{
    Porthole,
    Top
}
