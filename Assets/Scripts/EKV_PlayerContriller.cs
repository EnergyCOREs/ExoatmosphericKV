using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EKV_PlayerContriller : EKV_Controller
{




    public GameObject light;
    

    void Update()
    {
        _linearMovementVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.F))
        {
            light.SetActive(!light.activeInHierarchy);
        }

        _angleOfView += Input.GetAxis("Mouse X");
    }


}
