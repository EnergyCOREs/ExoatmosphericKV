using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform _transform;
    private Transform _camera;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _camera = Camera.main.transform;
    }

    void Update()
    {

        _transform.rotation = Quaternion.LookRotation(_camera.forward, _transform.TransformDirection(Vector3.forward));
    }
}
