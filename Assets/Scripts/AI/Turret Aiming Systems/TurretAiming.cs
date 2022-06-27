using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAiming : MonoBehaviour
{
    [SerializeField] private Vector3 _targetingOffset;
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
            _targetPosition = _targeting.ActiveTarget.transform.position + _targeting.ActiveTarget.transform.InverseTransformDirection(_targetingOffset);
        }
    }

    public void SetTargetingLead(float lead)
    {
        _targetingOffset.z = lead;
    }
}
