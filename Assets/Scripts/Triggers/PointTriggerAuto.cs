using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointTriggerAuto : PointTriggerBase
{
    [SerializeField]
    private float _delay = 0.2f;

    [SerializeField]
    private UnityEvent _TriggerOut;

    private float _timer = 0;

    private void Awake()
    {
        _timer = _delay;
    }

    private void Update()
    {
        if (!_active)
            return;

        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _timer = _delay;
            _TriggerOut?.Invoke();
        }
    }


}
