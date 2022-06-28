using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : Health
{
    protected override void OnDeath()
    {
        Destroy(gameObject);
        Debug.Log("Shield Down");
    }
}
