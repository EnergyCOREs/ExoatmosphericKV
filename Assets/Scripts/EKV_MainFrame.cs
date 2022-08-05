using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EKV_MainFrame : MonoBehaviour
{
    public EKV_Controller controller;
    public ConstantForce frc;
    public float forceF, forceS;

    private Transform thisTransform;
    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    void Update()
    {
        float transformAngle = Mathf.DeltaAngle(thisTransform.rotation.eulerAngles.y, controller.GetYaw());
        frc.relativeForce = controller.GetLinearMovementVector() * forceF;
        frc.relativeTorque = Vector3.up * transformAngle * forceS;
    }
}
