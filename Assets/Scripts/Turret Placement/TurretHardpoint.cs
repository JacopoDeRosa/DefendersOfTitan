using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHardpoint : MonoBehaviour
{
    [SerializeField] private TurretTypes _type;


    private TurretIdentifier _activeTurret;

    public void TryPlaceTurret(TurretIdentifier turret)
    {
        if (turret.TurretType != _type) return;

        if(_activeTurret != null)
        {
            Destroy(_activeTurret.gameObject);
        }
        _activeTurret = Instantiate(turret, transform.position, transform.rotation);
    }
}
