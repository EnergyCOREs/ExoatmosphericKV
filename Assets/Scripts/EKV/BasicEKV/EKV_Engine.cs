using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EKV_Engine : MonoBehaviour
{

    private Rigidbody _affectedBody;
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public virtual void Pulse(float force)
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
