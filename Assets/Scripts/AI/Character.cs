using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private bool _targeted;

    public bool Targeted { get => _targeted; }

    public void SetTargeted(bool targeted)
    {
        _targeted = targeted;
    }
}

