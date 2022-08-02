using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKV_Camera : MonoBehaviour
{
    [SerializeField]
    private Transform _cameraRigPivot;

    public EKV_Controller controller;

    [SerializeField]
    private Transform _target;

    void Update()
    {
        if (_target == null)
            return;

        _cameraRigPivot.position = Vector3.Lerp(_cameraRigPivot.position, _target.position, Time.deltaTime * 7f);
        _cameraRigPivot.rotation = Quaternion.Euler(new Vector3(0, controller.GetYaw(), 0));
    }
}
