using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class AiMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMesh;
    [SerializeField] private float _minDistance;

    public event Action onArrived;

    private Vector3 _destination;
    private bool _moving;

    public void SetDestination(Vector3 destination)
    {   
        _navMesh.SetDestination(destination);

        if (_moving == false)
        {
            _moving = true;
        }
        if(_navMesh.isStopped)
        {
            _navMesh.isStopped = false;
        }
        _destination = destination;
    }

    private void EndMove()
    {
        if (_moving == false) return;
         
        _moving = false;
        _navMesh.isStopped = true;
        onArrived?.Invoke();
    }

    private void Update()
    {
        if(_moving && Vector3.Distance(transform.position, _destination) <= _minDistance)
        {
            EndMove();
        }
    }
}
