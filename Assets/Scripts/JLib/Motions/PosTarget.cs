using System;
using UnityEngine;

public class PosTarget : VectorTarget
{
    public virtual PosTarget Init(Vector3 target, float speed, bool proportional = false, bool local = true)
    {
        this._setVector = (Vector3 v) => { this.SetPos(v, proportional, local); };
        this.Target = target;
        this.Speed = speed;
        return this;
    }

    public override void Update()
    {
        base.Update();
    }
}
