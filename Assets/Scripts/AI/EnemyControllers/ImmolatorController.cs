using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmolatorController : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private AiMover _mover;
    [SerializeField] private float _explosionSize;
    [SerializeField] private int _explosionDamage;
    [SerializeField] private LayerMask _damageMask;

    private void Awake()
    {
        _health.onDeath += OnDeath;
        _mover.onArrived += OnArrive;
        _mover.SetDestination(FindObjectOfType<WallAttackPoints>().GetRandomAttackPoint());
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }
    private void OnArrive()
    {
        Explode();
    }

    private void Explode()
    {
        Debug.Log("Boom");
        Collider[] colliders =  Physics.OverlapSphere(transform.position, _explosionSize, _damageMask);
        foreach (Collider collider in colliders)
        {
            if(collider.TryGetComponent(out Health health))
            {
                health.RemoveHp(_explosionDamage);
            }
        }
        _health.RemoveHp(500);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionSize);
    }
#endif
}
