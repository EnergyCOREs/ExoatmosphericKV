using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EKV_Billboard : MonoBehaviour
{
    private Transform _transform;
    private Transform _parent;
    private Transform _cameraTransform;

    // optimization
    Vector3 _engineNormal;
    Vector3 _directionFromCamera;
    Vector3 _projectedOnEngineNormal;

    [Inject]
    public void Construct(EKV_Camera _mainCamera)
    {
        _cameraTransform = _mainCamera.GetCameraTransform();
    }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _parent = _transform.parent;
    }


    public void RotateToCamera()
    {
        _engineNormal = _parent.TransformDirection(Vector3.forward); // fix
        _directionFromCamera = (_transform.position - _cameraTransform.position).normalized;
        _projectedOnEngineNormal = Vector3.ProjectOnPlane(_directionFromCamera, _engineNormal).normalized;
        _transform.localRotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(_parent.parent.TransformDirection(Vector3.forward), _projectedOnEngineNormal, _engineNormal));
    }
}
