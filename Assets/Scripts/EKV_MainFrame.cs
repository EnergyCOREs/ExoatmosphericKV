using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EKV_MainFrame : MonoBehaviour
{
    public EKV_Controller controller;
    public ConstantForce frc;
    public float forceF, forceS;

    private Transform _thisTransform;
    private void Awake()
    {
        _thisTransform = GetComponent<Transform>();
    }

    void Update()
    {
        float transformAngle = Mathf.DeltaAngle(_thisTransform.rotation.eulerAngles.y, controller.GetYaw());
        Debug.Log($" current rotation= {_thisTransform.rotation.eulerAngles.y} , need= {controller.GetYaw()} , need= {transformAngle} ");
        frc.relativeForce = controller.GetLinearMovementVector() * forceF;
        frc.relativeTorque = Vector3.up * transformAngle * forceS;
    }
}
