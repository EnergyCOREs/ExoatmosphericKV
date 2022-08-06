using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EKV_MeshMovementSmoother 
{
    [SerializeField]
    private float _smoothFactor= 0.7f;

    private Vector3 _accumulator;

    public Vector3 GetNewPosition(Vector3 currentPosition)
    {
        _accumulator = Vector3.Slerp(currentPosition, _accumulator, _smoothFactor);
        return _accumulator;
    }

    public void Init(Vector3 currentPosition)
    {
        _accumulator = currentPosition;
    }
}
