using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortholeAiming : TurretAiming
{
    [SerializeField] private Transform _ball;


    [SerializeField] private float _maxGimbal;
    [SerializeField] private float _ballRotHardness;

    
    Quaternion _ballTargetRot;

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_targetPosition, 0.25f);
    }
#endif

    protected override void Update()
    {
        base.Update();
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
