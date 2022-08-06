using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EKV_BasicEngine : EKV_Engine
{
    [SerializeField]
    private EKV_FlameEffect _flameEffect;

    private int _nextAllowedTimeForEffect;

    [SerializeField]
    private const int _tickDelayForEffect = 9;

    public override void Pulse(float force)
    {
        base.Pulse(force);
        if (_nextAllowedTimeForEffect <= 0)
        {
            _nextAllowedTimeForEffect = _tickDelayForEffect;
            _flameEffect.Puff();
        }
    }

    private void FixedUpdate()
    {
        _nextAllowedTimeForEffect--;
    }

}
