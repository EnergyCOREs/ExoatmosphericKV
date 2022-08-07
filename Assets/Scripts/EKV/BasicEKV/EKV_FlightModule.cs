using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKV_FlightModule
{
    private EKV_Engine[] _enginesArrayUp, _enginesArrayDown;
    private Rigidbody _rigidbody;
    private Transform _transform;

    private struct PreparedEngine
    {

    }

    private float GetAngle()
    {
        Vector3 _bodyNormal = _transform.TransformDirection(Vector3.up);
        return Vector3.Angle(Vector3.up, _bodyNormal) * Mathf.Sign(Vector3.Dot(_bodyNormal, Vector3.right));
    }
}
