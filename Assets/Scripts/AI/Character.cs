using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Health _health;

    public bool Targeted { get; private set; }

    public void SetTargeted(bool targeted)
    {
        //Targeted = targeted;
    }
}

