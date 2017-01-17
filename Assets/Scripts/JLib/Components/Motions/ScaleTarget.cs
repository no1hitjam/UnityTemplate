using UnityEngine;

public class ScaleTarget : VectorTarget
{
    public virtual ScaleTarget Init(Vector3 target, float speed, Vector3? axes = null, bool eased = true, float drift = 0)
    {
        base.Init(this.GetScale, this.SetScale, target, speed, axes, eased, drift);
        return this;
    }

    public override void Update()
    {
        base.Update();
    }
}

