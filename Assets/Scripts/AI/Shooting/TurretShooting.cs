using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    [SerializeField] private TurretTargeting _targeting;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private Projectile _bulletTemplate;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _timeUntilRetarget = 2;

    private float _nextShotTime;
    private float _enemyMissedTimer;

    private void Update()
    {
        if (_targeting.ActiveTarget != null && _enemyMissedTimer < _timeUntilRetarget)
        {
            if (Physics.Raycast(new Ray(_muzzle.position, _muzzle.forward), Mathf.Infinity, _targeting.TargetingMask))
            {
                TryFire();
                _enemyMissedTimer = 0;
            }
            else
            {
                _enemyMissedTimer += Time.deltaTime;
            }
        }
        else if(_targeting.ActiveTarget != null && _enemyMissedTimer > _timeUntilRetarget)
        {
            _enemyMissedTimer = 0;
            _targeting.ResetTarget();
        }
    }

    private void TryFire()
    {
        if (_nextShotTime <= Time.time)
        {
            Instantiate(_bulletTemplate, _muzzle.position, _muzzle.rotation);
            _nextShotTime = Time.time + _fireRate;
        }
    }

}
