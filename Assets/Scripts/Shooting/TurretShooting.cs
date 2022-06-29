using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    [SerializeField] private TurretTargeting _targeting;
    [SerializeField] private AudioClip _shootingClip;
    [SerializeField] private Transform[] _muzzles;
    [SerializeField] private Projectile _bulletTemplate;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _timeUntilRetarget = 2;
    [SerializeField] private float _spread;

    private float _nextShotTime;
    private float _enemyMissedTimer;
    private int _activeMuzzle;

    private void Update()
    {
        if (_targeting.ActiveTarget != null && _enemyMissedTimer < _timeUntilRetarget)
        {
            if (Physics.SphereCast(new Ray(_muzzles[_activeMuzzle].position, _muzzles[_activeMuzzle].forward), 0.5f,Mathf.Infinity, _targeting.TargetingMask))
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
            Instantiate(_bulletTemplate, _muzzles[_activeMuzzle].position, _muzzles[_activeMuzzle].rotation * Quaternion.Euler(Random.Range(-_spread, _spread), Random.Range(-_spread, _spread), 0));
            _nextShotTime = Time.time + _fireRate;
            if(_shootingClip)
            {
                AudioSource.PlayClipAtPoint(_shootingClip, _muzzles[_activeMuzzle].position);
            }
            CycleMuzzle();
        }
    }

    private void CycleMuzzle()
    {
        if (_muzzles.Length == 1) return;

        if(_activeMuzzle == _muzzles.Length -1)
        {
            _activeMuzzle = 0;
        }
        else
        {
            _activeMuzzle++;
        }
    }
}
