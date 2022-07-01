using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretIdentifier : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _cost;
    [SerializeField] private TurretTypes _turretType;



    public Sprite Icon { get => _icon; }
    public TurretTypes TurretType { get => _turretType; }
    public int TurretCost { get => _cost; }
}

public enum TurretTypes
{
    Porthole,
    Top
}
