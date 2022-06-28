using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquireController : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private AiMover _mover;

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
        
    }
}
