using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasePool : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    [SerializeField]
    private float _premakeCount = 10f;

    protected private Transform _transform;

    protected private List<BasePoolObject> _allPullObjects = new List<BasePoolObject>();

    public virtual void Awake()
    {
        _transform = this.transform;
        GameObject instantiatedPoolObject;
        for (int i = 0; i < _premakeCount; i++)
        {
            instantiatedPoolObject = Instantiate(_prefab, _transform);
            _allPullObjects.Add(instantiatedPoolObject.GetComponent<BasePoolObject>()); // unsafe
            instantiatedPoolObject.SetActive(false);
        }
    }

    public BasePoolObject Pull(Vector3 position)
    {
        BasePoolObject _preparedPoolObject;

        if (_transform.childCount > 0)
        {
            Transform _childTransform = _transform.GetChild(0);

            _childTransform.position = position;
            _preparedPoolObject = _childTransform.GetComponent<BasePoolObject>();
            _preparedPoolObject.owner = _transform;
            _preparedPoolObject.Pull();
        }
        else
        {
            var instantiatedObject = Instantiate(_prefab, position, Quaternion.identity);
            _preparedPoolObject = instantiatedObject.GetComponent<BasePoolObject>();

            _preparedPoolObject.owner = _transform;
            _preparedPoolObject.Pull();
            _allPullObjects.Add(_preparedPoolObject);
        }


        return _preparedPoolObject;
    }

    private void ClearDeletedObjectsInPoolList()
    {
        _allPullObjects.RemoveAll((a) => a == null);
    }

    public void ForcePushAll()
    {
        ClearDeletedObjectsInPoolList();

        foreach (var item in _allPullObjects)
        {
            if (item.isActiveAndEnabled)
                item.Push();
        }
    }

}
