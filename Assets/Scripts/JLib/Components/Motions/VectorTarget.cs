using System;
using System.Collections.Generic;
using UnityEngine;

public class VectorTarget : Motion
{
    protected Func<Vector3> _getVector;
    protected Action<Vector3> _setVector;

    public Vector3 Target;
    public bool Eased;
    public float Drift;
    public Vector3 Axes;

    private float _speed;
    public float Speed
    {
        get {
            var returnSpeed = _speed;
            var distance = Vector3.Distance(_getVector(), Target);
            if (!Eased) {
                returnSpeed /= distance;
            }
            if (Drift != 0 && distance > Drift) {
                returnSpeed *= .01f;
            }
            return returnSpeed;
        }
        set { _speed = value; }
    }

    /// <param name="axes">default: all</param>
    /// <param name="drift">distance to drift</param>
    public virtual VectorTarget Init(Func<Vector3> getVector, Action<Vector3> setVector, Vector3 target, 
        float speed, Vector3? axes = null, bool eased = true, float drift = 0)
    {
        _getVector = getVector;
        _setVector = setVector;
        Target = target;
        Speed = speed;
        Axes = JLib.ReduceToAxes(axes);
        Eased = eased;
        Drift = drift;
        return this;
    }

    public virtual void Update()
    {
        if (ActiveFrame) {
            var distance = _getVector().JDistance(Target, Axes);
            if (_getVector() != Target) {
                _setVector(_getVector() + (Target - _getVector()).NewScale(Axes) * Speed);
            }
        }
    }
}
