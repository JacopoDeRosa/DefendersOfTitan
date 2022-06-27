using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    private const int targetingBufferSize = 20;

    [SerializeField] private float _pingRange;
    [SerializeField] private float _pingInterval;
    [SerializeField] private LayerMask _targetingMask;
    [SerializeField] private bool _allowPings = true;

    private float _nextPingTime;

    private Collider[] _possibleTargets;

    public Character ActiveTarget { get; private set; }
    public LayerMask TargetingMask { get => _targetingMask; }

    public void ResetTarget()
    {
        if (ActiveTarget != null)
        {
            ActiveTarget.SetTargeted(false);
            ActiveTarget = null;
        }
    }

    private void Awake()
    {
        _possibleTargets = new Collider[targetingBufferSize];
    }

    private void TryPingTarget()
    {
        Physics.OverlapSphereNonAlloc(transform.position, _pingRange, _possibleTargets, _targetingMask);

        foreach (Collider collider in _possibleTargets)
        {
            if (collider == null) break;

            if (collider.TryGetComponent(out Character character) && character.Targeted == false)
            {
                ActiveTarget = character;
                character.SetTargeted(true);
                return;
            }
        }
    }

    private void Update()
    {
        if (ActiveTarget == null && Time.time >= _nextPingTime && _allowPings)
        {
            TryPingTarget();
            _nextPingTime = Time.time + _pingInterval;
        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _pingRange);

        Gizmos.color = Color.red;

        if (ActiveTarget != null)
        {
            Gizmos.DrawWireSphere(ActiveTarget.transform.position, 0.4f);
        }

        Gizmos.color = Color.green;
        if (_possibleTargets != null)
        {
            foreach (Collider collider in _possibleTargets)
            {
                if (collider != null)
                {
                    Gizmos.DrawWireSphere(collider.transform.position, 0.3f);
                }
            }
        }
    }
#endif


}
