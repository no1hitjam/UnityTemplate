using System;
using UnityEngine;

public class VectorTarget : VectorTargetBase
{
    public new VectorTargetBase Init(Func<Vector4> getVector = null, Action<Vector4> setVector = null, Vector4? target = null,
        int? time = null, Vector4? axes = null, EaseType? easing = null)
    {
        base.Init(getVector, setVector, target, time, axes, easing);
        return this;
    }

    public override void Update()
    {
        base.Update();
    }
}

