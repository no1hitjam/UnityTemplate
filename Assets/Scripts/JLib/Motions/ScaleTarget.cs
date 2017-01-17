using UnityEngine;

public class ScaleTarget : VectorTarget
{
    public virtual ScaleTarget Init(Vector3 target, float speed)
    {
        this._setVector = this.SetScale;
        this.Target = target;
        this.Speed = speed;
        return this;
    }

    public override void Update()
    {
        base.Update();
    }
}

