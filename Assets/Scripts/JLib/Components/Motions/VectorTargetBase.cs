using System;
using System.Collections.Generic;
using UnityEngine;

public enum EaseType { In, Out, Both, None }

public abstract class VectorTargetBase : Motion
{
    private static readonly Dictionary<EaseType, Func<VectorTargetBase, Vector4>> _vectorChange = new Dictionary<EaseType, Func<VectorTargetBase, Vector4>>{
        { EaseType.None, (VectorTargetBase b) => {
            return b.Difference * b.TimeProportion;
        } },
        { EaseType.In, (VectorTargetBase b) => {
            return b.Difference * Mathf.Pow(b.TimeProportion, 2);
        } },
        { EaseType.Out, (VectorTargetBase b) => {
            return -b.Difference * b.TimeProportion * (b.TimeProportion - 2);
        } },
        { EaseType.Both, (VectorTargetBase b) => {
            if (b.TimeProportion < .5f) {
                return b.Difference * Mathf.Pow(b.TimeProportion, 2) * 2;
            }
            return b.Difference *  (Mathf.Pow(b.TimeProportion * 2 - 2, 2) - 2) * -.5f;
        } },
    };


    protected Func<Vector4> _getVector;
    protected Action<Vector4> _setVector;

    private Vector4 _start;
    private Vector4 _target = Vector4.zero;
    private int _time;
    private int _maxTime = 30;
    private EaseType _easing = EaseType.Out;
    private Vector4 _axes = JLib.AxesAll;
    
    public float TimeProportion { get { return (float)_time / _maxTime; } }
    public Vector4 Difference { get { return _target - _start; } }

    /// <param name="axes">default: all</param>
    /// <param name="drift">distance to drift</param>
    protected virtual VectorTargetBase Init(Func<Vector4> getVector = null, Action<Vector4> setVector = null, Vector4? target = null, 
        int? time = null, Vector4? axes = null, EaseType? easing = null)
    {
        _getVector = getVector ?? _getVector;
        _start = _getVector();
        _setVector = setVector ?? _setVector;
        _target = target ?? _target;
        _time = 0;
        _maxTime = time ?? _maxTime;
        _axes = axes ?? _axes;
        _easing = easing ?? _easing;
        return this;
    }

    public virtual void Update()
    {
        if (ActiveFrame) {
            if (_time <= _maxTime) {
                _setVector(_start + _vectorChange[_easing](this));
                _time++;
            }
        }
    }
}
