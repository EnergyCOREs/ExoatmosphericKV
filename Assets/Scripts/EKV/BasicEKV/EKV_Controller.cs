using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class EKV_Controller : MonoBehaviour
{
    
    protected float _angleOfView;
    protected Vector3 _linearMovementVector;
    public Action OnLightChange;
    public Action OnLightToggle;

    protected Transform _mainFrameTransform;
    protected Rigidbody _mainFrameRigidbody;

    public float GetYaw()
    {
        _angleOfView = _angleOfView % 360;
        return _angleOfView;
    }

    public Vector3 GetLinearMovementVector()
    {
        return _linearMovementVector;
    }

    public Vector3 GetMainFrameForwardVector()
    {
        if (_mainFrameRigidbody == null)
            throw new Exception("_mainFrameTransform is Null");

        return _mainFrameTransform.TransformDirection(Vector3.forward);
    }

    public Vector3 GetMainFrameVelocity()
    {
        if (_mainFrameRigidbody == null)
            throw new Exception("_mainFrameRigidbody is Null");

        return _mainFrameRigidbody.velocity;
    }

    public void SetBodyParameters(Transform mainFrameTransform, Rigidbody mainFrameRigidbody)
    {
        _mainFrameTransform = mainFrameTransform;
        _mainFrameRigidbody = mainFrameRigidbody;
    }

    public void ClearBodyParameters()
    {
        _mainFrameTransform = null;
        _mainFrameRigidbody = null;
    }

}
