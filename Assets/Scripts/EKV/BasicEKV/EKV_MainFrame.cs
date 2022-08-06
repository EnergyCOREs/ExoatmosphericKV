using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EKV_MainFrame : MonoBehaviour
{
    [SerializeField]
    private Transform _meshRig;

    [SerializeField]
    private EKV_Controller _controller;

    [SerializeField]
    private EKV_MeshMovementSmoother _meshPositionSmoother = new EKV_MeshMovementSmoother();

    [SerializeField]
    private EKV_Light _light;

    public ConstantForce frc;
    public float forceF, forceS, power = 100;

    private Rigidbody _rigidbody;
    private Transform _transform;

    [Tooltip("front left, front right, rear left, rear right")]
    [SerializeField, SerializeReference]
    private EKV_Engine[] _enginesArrayUp, _enginesArrayDown;

    private float _fixedUpdateCounter;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();

        _meshPositionSmoother.Init(_transform.position);

        InitEngines();
        PossessByController(_controller);
    }

    private void InitEngines()
    {
        for (int i = 0; i < 4; i++)
        {
            _enginesArrayUp[i].Init(_rigidbody);
            _enginesArrayDown[i].Init(_rigidbody);
        }
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

    private void FixedUpdate() // HACK! this kinematic rigidbody never going to sleep
    {
        _rigidbody.MovePosition(_rigidbody.position);

        _meshRig.position = _meshPositionSmoother.GetNewPosition(_transform.position);

        foreach (var engine in _enginesArrayDown)
        {
            engine.Pulse(power);
        }


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            foreach (var engine in _enginesArrayDown)
            {
                engine.Pulse(power);
            }
        }

        return;
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
