using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EKV_Controller : MonoBehaviour
{
    
    protected float _angleOfView;
    protected Vector3 _linearMovementVector;
    public float GetYaw()
    {
        _angleOfView = _angleOfView % 360;
        return _angleOfView;
    }

    public Vector3 GetLinearMovementVector()
    {
        return _linearMovementVector;
    }

}
