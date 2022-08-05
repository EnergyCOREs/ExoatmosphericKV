using System.Collections;
using UnityEngine;

public abstract class BasePoolObject : MonoBehaviour
{
    public Transform owner { get; set; }

    protected private GameObject _gameObject { get; private set; }
    protected private Transform _transform { get; private set; }

    private bool _isPushDelayed = false;

    public virtual void Awake()
    {
        Init();
    }

    public void Init()
    {
        _gameObject = gameObject;
        _transform = transform;
    }

    public void Push()
    {
        if (_isPushDelayed)
        {
            StopAllCoroutines();
            _isPushDelayed = false;
        }

        OnPush();
        _gameObject.SetActive(false);

        if (owner == null)
        {
            Destroy(_gameObject);
            throw new System.Exception("Owner not set! Check previos exceptions");
        }

        _transform.SetParent(owner);
    }

    public void PushDelayed(float time)
    {
        if (_gameObject.activeInHierarchy != false)
        {
            StartCoroutine(PushRoutine(time));
        }
    }


    private IEnumerator PushRoutine(float time)
    {
        _isPushDelayed = true;
        yield return new WaitForSeconds(time);
        _isPushDelayed = false;
        Push();
    }

    public void Pull()
    {
        _gameObject.SetActive(true);
        _transform.parent = null;
        OnPull();
    }

    public abstract void OnPull();
    public abstract void OnPush();
}
