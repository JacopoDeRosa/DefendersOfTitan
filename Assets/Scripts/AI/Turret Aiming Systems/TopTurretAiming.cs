using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTurretAiming : TurretAiming
{
    [SerializeField] private Transform _turretRing;
    [SerializeField] private Transform _cannon;
    [SerializeField] private float _ringRotationHardness;
    [SerializeField] private float _cannonRotationHardness;
    [SerializeField] private float _maxElevation, _maxDepression;

    Quaternion _ringTargetRot;
    Quaternion _cannonTargetRot;

    float _cannonAngle;

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_targetPosition, 0.25f);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Ray(_cannon.position, Quaternion.AngleAxis(_maxElevation * -1, transform.right) * _cannon.forward));
        Gizmos.DrawRay(new Ray(_cannon.position, Quaternion.AngleAxis(_maxDepression * -1, transform.right) * _cannon.forward));
    }
#endif

    protected override void Update()
    {
        base.Update();
        RotateTurretRing();
        RotateCannon();
    }

    private void RotateTurretRing()
    {
        _ringTargetRot = Quaternion.LookRotation(new Vector3(_targetPosition.x, _turretRing.position.y, _targetPosition.z) - transform.position, transform.up);

        _turretRing.rotation = Quaternion.Lerp(_turretRing.rotation, _ringTargetRot, Mathf.Clamp01(_ringRotationHardness * Time.deltaTime));
    }

    private void RotateCannon()
    {
        float angle = Vector3.SignedAngle(_turretRing.forward, _targetPosition - _turretRing.position, _cannon.right);

        angle = Mathf.Clamp(angle, _maxElevation * -1, _maxDepression * -1);

        _cannonTargetRot = Quaternion.AngleAxis(angle, transform.right);

        _cannon.localRotation = Quaternion.Lerp(_cannon.localRotation, _cannonTargetRot, Mathf.Clamp01(_cannonRotationHardness * Time.deltaTime));
    }
}

