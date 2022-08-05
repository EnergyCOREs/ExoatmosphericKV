using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface I_EKV_Body
{

}

public interface I_EKV_Engine
{
    public void Pulse(float force);
    public void Init(Rigidbody affectedBody);
}