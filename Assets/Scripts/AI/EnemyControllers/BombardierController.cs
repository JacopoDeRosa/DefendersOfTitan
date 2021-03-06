using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardierController : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private AudioClip _shootingClip;
    [SerializeField] private AiMover _mover;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Projectile _projectile;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _recoil;

    private float _nextShotTime;
    private bool _shooting;
    private WallAttackPoints _wallAttackPoints;
    private Vector3 _attackPoint;

    private void Awake()
    {
        _health.onDeath += OnDeath;

        _mover.onArrived += OnArrive;

        _wallAttackPoints = FindObjectOfType<WallAttackPoints>();

        _attackPoint = _wallAttackPoints.GetRandomAttackPoint();

        _mover.SetDestination(_attackPoint);
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }
    private void OnArrive()
    {
        _shooting = true;
    }

    private void Update()
    {
        if(_shooting && Time.time > _nextShotTime)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(_projectile, _muzzle.position, _muzzle.rotation);
        _nextShotTime = Time.time + _fireRate;
        AudioSource.PlayClipAtPoint(_shootingClip, _muzzle.position);
        _rigidbody.AddForce(-transform.forward * _recoil, ForceMode.Impulse);
    }
}
