using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EKV_MainFrame : MonoBehaviour
{
    [SerializeField]
    public EKV_Controller _controller;

    [SerializeField]
    private EKV_Light _light;

    public ConstantForce frc;
    public float forceF, forceS;

    private Rigidbody _rigidbody;
    private Transform _transform;

    [Tooltip("front left, front right, rear left, rear right")]
    [SerializeField, SerializeReference]
    private EKV_Engine[] _enginesArrayUp, _enginesArrayDown;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
        PossessByController(_controller);
    }

    public void UnpossessCurentController()
    {
        _controller.ClearBodyParameters();
        _controller.OnLightToggle -= ToggleLight;
    }

    public void PossessByController(EKV_Controller controller)
    {
        UnpossessCurentController();
        _controller = controller;
        _controller.SetBodyParameters(_transform, _rigidbody);
        _controller.OnLightToggle += ToggleLight;
    }

    private void Update()
    {
        float transformAngle = Mathf.DeltaAngle(_transform.rotation.eulerAngles.y, _controller.GetYaw());
        frc.relativeForce = _controller.GetLinearMovementVector() * forceF;
        frc.relativeTorque = Vector3.up * transformAngle * forceS;
    }

    private void ToggleLight()
    {
        _light.Toggle();
    }


    private void OnDestroy()
    {
        UnpossessCurentController();
    }
}
