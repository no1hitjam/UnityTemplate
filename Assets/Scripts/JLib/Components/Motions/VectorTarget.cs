using UnityEngine;
using UnityEngine.Events;

public class VectorTarget : MonoBehaviour
{
    protected UnityAction<Vector3> _setVector;
    public Vector3 Target;
    public float Speed;

    public virtual VectorTarget Init(UnityAction<Vector3> setVector, Vector3 target, float speed)
    {
        this._setVector = setVector;
        this.Target = target;
        this.Speed = speed;
        return this;
    }

    public virtual void Update()
    {
        // TODO: logic for finding new vector
        var new_vector = Vector3.one;
        _setVector(new_vector);
    }
    

    public void Test()
    {
        var test = new GameObject().AddComponent<SpriteRenderer>();
        test.Add<VectorTarget>().Init((Vector3 v) => { test.SetPos(v); }, Vector3.zero, .1f);
        test.Add<VectorTarget>().Init(test.SetScale, Vector3.one, .2f);
    }
}
