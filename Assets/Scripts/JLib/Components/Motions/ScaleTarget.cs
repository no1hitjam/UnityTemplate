using UnityEngine;

public class ScaleTarget : VectorTargetBase
{
    public virtual ScaleTarget Init(Vector3 target, int? time = null, Vector3? axes = null, EaseType? eased = null)
    {
        base.Init(
            () => { return this.GetScale(); },
            (v) => { this.SetScale(v); }, 
            target, time, axes, eased);
        return this;
    }

    public override void Update()
    {
        base.Update();
    }
}

