using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAttackPoints : MonoBehaviour
{
    [SerializeField] private Vector3[] _attackPositions;

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        foreach (Vector3 point in _attackPositions)
        {
            Gizmos.DrawSphere(point, 0.4f);
        }
    }
#endif

    public Vector3 GetRandomAttackPoint()
    {
        return _attackPositions[Random.Range(0, _attackPositions.Length - 1)];
    }
}
