using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMesh;

    public event Action onArrived;

    public void SetDestination(Vector3 destination)
    {
        _navMesh.SetDestination(destination);
    }
}
