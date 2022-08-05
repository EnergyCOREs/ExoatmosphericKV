using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EKV_BasicEngine : MonoBehaviour, I_EKV_Engine
{
    private Rigidbody _affectedBody;
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {

    }

    public void Pulse(float force)
    {
        var _forward = _transform.TransformDirection(Vector3.forward);
        _affectedBody.AddForceAtPosition(_forward * force, _transform.position, ForceMode.Impulse);
    }

    public void Init(Rigidbody maiframeBody)
    {
        _affectedBody = maiframeBody;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.01f);
        Gizmos.DrawLine(transform.position, transform.position + transform.TransformDirection(Vector3.forward) * 0.3f);
    }
}
