using UnityEngine;

[System.Serializable]
public class PidRegulator
{
    [SerializeField] private float _ki;
    [SerializeField] private float _kp;
    [SerializeField] private float _kd;
    [SerializeField] private float _maxOut = 1000;
    [SerializeField] private float _minOut = -1000;


    private float _integral, _oldError, _currentError, _currentD, _targetPoint;

    public PidRegulator(float ki, float kp, float kd)
    {
        _ki = ki;
        _kp = kp;
        _kd = kd;
    }

    private float ComputePID(float time, float input)
    {
        _currentError = _targetPoint - input;
        _integral = Mathf.Clamp(_integral + _currentError * time * _ki, _minOut, _maxOut);
        _currentD = (_currentError - _oldError) / time;
        _oldError = _currentError;
        return Mathf.Clamp(_currentError * _kp + _integral + _currentD * _kd, _minOut, _maxOut);
    }

    public float Tick(float time, float input)
    {
        return ComputePID(time, input);
    }

    public void SetPoint(float point)
    {
        _targetPoint = point;
    }

    public void SetMaxMin(float max, float min)
    {
        _maxOut = max;
        _minOut = min;
    }

}
