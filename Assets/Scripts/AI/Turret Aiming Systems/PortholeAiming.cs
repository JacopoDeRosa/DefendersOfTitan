using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortholeAiming : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private TurretTargeting _targeting;
    [SerializeField] private float _maxGimbal;
    [SerializeField] private float _ballRotHardness;

    private Vector3 _targetPosition;
    Quaternion _ballTargetRot;

    private void Update()
    {
        if (_targeting.ActiveTarget == null)
        {
            _targetPosition = transform.forward;
        }
        else
        {
            _targetPosition = _targeting.ActiveTarget.transform.position;
        }

        RotateBall();
    }

    private void RotateBall()
    {
        _ballTargetRot = Quaternion.LookRotation(_targetPosition - transform.position);
        float rotationY = 0;
        float rotationX = 0;

        if(_ballTargetRot.eulerAngles.y < 180)
        {
            rotationY = Mathf.Clamp(_ballTargetRot.eulerAngles.y, 0, _maxGimbal);
        }
        else
        {
            rotationY = Mathf.Clamp(_ballTargetRot.eulerAngles.y, 360 - _maxGimbal, 360);
        }

        if(_ballTargetRot.eulerAngles.x < 180)
        {
            rotationX = Mathf.Clamp(_ballTargetRot.eulerAngles.x, 0, _maxGimbal);
        }
        else
        {
            rotationX = Mathf.Clamp(_ballTargetRot.eulerAngles.x, 360 - _maxGimbal, 360);
        }



        _ballTargetRot = Quaternion.Euler(rotationX, rotationY, 0);

        _ball.rotation = Quaternion.Lerp(_ball.rotation, _ballTargetRot, Mathf.Clamp01(_ballRotHardness * Time.deltaTime));
        
    }
}
