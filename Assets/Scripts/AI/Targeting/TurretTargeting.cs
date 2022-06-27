using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    [SerializeField] private Vector3 _pingBoxSize;
    [SerializeField] private Vector3 _pingBoxCenter;
    [SerializeField] private float _pingInterval;
    [SerializeField] private LayerMask _targetingMask;
    [SerializeField] private bool _allowPings = true;

    private float _nextPingTime;

    private Collider[] _possibleTargets;

    private Character _lastTarget;
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

    private void TryPingTarget()
    {
        _possibleTargets = Physics.OverlapBox(transform.position + _pingBoxCenter, _pingBoxSize / 2, Quaternion.identity, _targetingMask);

        foreach (Collider collider in _possibleTargets)
        {
            if (collider == null) break;

            if (collider.TryGetComponent(out Character character) && character.Targeted == false)
            {
                if(_lastTarget != null && _lastTarget == character)
                {
                    return;
                }
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
        Gizmos.DrawWireCube(_pingBoxCenter + transform.position, _pingBoxSize);

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
