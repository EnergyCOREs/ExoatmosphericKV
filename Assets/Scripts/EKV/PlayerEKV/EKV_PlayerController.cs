using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EKV_PlayerController : EKV_Controller
{


    void Update()
    {
        _linearMovementVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
        _angleOfView += Input.GetAxis("Mouse X");

        if (Input.GetKeyDown(KeyCode.F))
        {
            OnLightToggle?.Invoke();
        }
    }



}
