using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    [SerializeField] private TurretTargeting _targeting;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private Projectile _bulletTemplate;
    [SerializeField] private float _fireRate;

    private float _nextShotTime;

    private void Update()
    {
        if (_targeting.ActiveTarget != null && Physics.Raycast(new Ray(_muzzle.position, _muzzle.forward), Mathf.Infinity, _targeting.TargetingMask))
        {
            TryFire();
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
