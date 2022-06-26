using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _collisionMask;

    private float _currentLifeTime;

    private void FixedUpdate()
    {
        if(_currentLifeTime >= _lifeTime)
        {
            Destroy(gameObject);
        }
        else
        {
            _currentLifeTime += Time.fixedDeltaTime;
        }

        Ray checkRay = new Ray(transform.position, transform.forward);

        if(Physics.Raycast(checkRay, out RaycastHit hit,_speed * Time.fixedDeltaTime, _collisionMask))
        {
            if(hit.transform.TryGetComponent(out Health health))
            {
                health.RemoveHp(_damage);
            }
            Destroy(gameObject);
        }
        else
        {
            Vector3 translation = new Vector3(0, 0, _speed * Time.fixedDeltaTime);
            transform.Translate(translation, Space.Self);
        }
        
    }
}
