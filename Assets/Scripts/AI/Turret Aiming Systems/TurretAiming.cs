using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAiming : MonoBehaviour
{
    [SerializeField] private float _targetingHeight = 0.5f;
    [SerializeField] private float _targetingLead = 1;

    [SerializeField] private TurretTargeting _targeting;

    protected Vector3 _targetPosition;

    protected virtual void Update()
    {
        if (_targeting.ActiveTarget == null)
        {
            _targetPosition = transform.position + transform.forward;
        }
        else
        {
            _targetPosition = _targeting.ActiveTarget.transform.position + _targeting.ActiveTarget.transform.forward * _targetingLead + new Vector3(0, _targetingHeight, 0);
        }
    }

    public void SetTargetingLead(float lead)
    {
        _targetingLead = lead;
    }
}
