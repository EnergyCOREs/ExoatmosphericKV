using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_EKV_Trigger
{
    public void Activate();
    public void Deactivate();
    public void Toggle();
    public bool GetState();
}

public interface I_EKV_Body
{

}

public interface I_EKV_Engine
{
    public void Pulse(float force);
}