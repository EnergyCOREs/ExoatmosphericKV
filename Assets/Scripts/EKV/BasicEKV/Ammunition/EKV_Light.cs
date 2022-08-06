using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKV_Light : MonoBehaviour, IPointTrigger
{
    [SerializeField]
    private GameObject _light;

    public void Activate()
    {
        _light.SetActive(true);
    }

    public void Deactivate()
    {
        _light.SetActive(false);
    }

    public bool GetState()
    {
        return _light.activeInHierarchy;
    }

    public void Toggle()
    {
        _light.SetActive(!_light.activeInHierarchy);
    }


}
