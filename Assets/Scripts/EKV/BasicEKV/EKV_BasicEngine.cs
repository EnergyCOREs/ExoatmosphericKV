using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EKV_BasicEngine : EKV_Engine
{
    [SerializeField]
    private EKV_FlameEffect _flameEffect;

    public override void Pulse(float force)
    {
        base.Pulse(force);
        _flameEffect.Puff();
    }

}
