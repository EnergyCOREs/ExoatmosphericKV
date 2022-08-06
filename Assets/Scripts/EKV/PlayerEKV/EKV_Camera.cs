using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKV_Camera : MonoBehaviour
{
    [SerializeField]
    private Transform _cameraRigPivot;
    [SerializeField]
    private Transform _cameraRigHead;

    public EKV_Controller controller;

    [SerializeField]
    private Transform _target;

    private float _vericalAngle = 0;

    public void Construct()
    {

    }

    void Update()
    {
        if (_target == null)
            return;

        _cameraRigPivot.position = Vector3.Lerp(_cameraRigPivot.position, _target.position, Time.deltaTime * 7f);
        _cameraRigPivot.rotation = Quaternion.Euler(new Vector3(0, controller.GetYaw(), 0));
        _vericalAngle = Mathf.Clamp(_vericalAngle - Input.GetAxis("Mouse Y"), -20f, 45f);
        _cameraRigHead.localRotation = Quaternion.Euler(_vericalAngle ,0, 0);
    }

    public Transform GetCameraTransform()
    {
        return _cameraRigHead;
    }
}
