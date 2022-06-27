using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : Projectile
{
    [SerializeField] private float _explosiveRange;

    protected override void OnHit(RaycastHit hit)
    {
        Collider[] colliders = Physics.OverlapSphere(hit.point, _explosiveRange, _collisionMask);
        foreach (Collider collider in colliders)
        {
            if(collider.TryGetComponent(out Health hp))
            {
                hp.RemoveHp(_damage);
            }
        }
        Destroy(gameObject);
    }
}
