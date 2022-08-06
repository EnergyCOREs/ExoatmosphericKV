using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDamageble
{
    public float Health { get; set; }

    public void TakeDamage();

    public enum DamageType
    {
        Bullet = 0,
        Electromagnetic,
        PhysicImpact,
        Overload
    }
}