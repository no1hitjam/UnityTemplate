using System;
using UnityEngine;

public class PosTarget : VectorTarget
{
    public virtual PosTarget Init(Vector3 target, float speed, bool proportional = false, bool local = true, 
        Vector3? axes = null, bool eased = true, float drift = 0)
    {
        base.Init(
            () => this.GetPos(proportional, local),
            (v) => this.SetPos(v, proportional, local),
            target,
            speed,
            axes,
            eased,
            drift);

        return this;
    }

    public override void Update()
    {
        base.Update();
    }
}
