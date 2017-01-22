using System;
using UnityEngine;

public class PosTarget : VectorTargetBase
{
    private bool _proportional = false;
    private bool _local = true;

    public virtual PosTarget Init(Vector3? target = null, int? time = null, bool? proportional = null, bool? local = null, 
        Vector3? axes = null, EaseType? eased = null)
    {
        _proportional = proportional ?? _proportional;
        _local = local ?? _local;
        base.Init(
            () => this.GetPos(_proportional, _local),
            (v) => this.SetPos(v, _proportional, _local),
            target,
            time,
            axes,
            eased);

        return this;
    }

    public override void Update()
    {
        base.Update();
    }
}
