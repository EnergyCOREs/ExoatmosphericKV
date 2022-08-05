using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPointTrigger
{
    public void Activate();
    public void Deactivate();
    public void Toggle();
    public bool GetState();
}


public abstract class PointTriggerBase : MonoBehaviour, IPointTrigger
{
    [SerializeField]
    protected bool _active;

    protected Color _gizmoColor = Color.magenta;

    public virtual void Activate()
    {
        _active = true;
    }

    public virtual void Deactivate()
    {
        _active = false;
    }

    public virtual bool GetState()
    {
        return _active;
    }

    public virtual void Toggle()
    {
        _active = !_active;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawSphere(transform.position, 0.01f);
    }

}
