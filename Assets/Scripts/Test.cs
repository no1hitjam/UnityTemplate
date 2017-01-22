using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Test : MonoBehaviour
{
    void Awake()
    {
        var test_renderers = new List<SpriteRenderer>().AddComponents(4, (i) =>
        {
            var r = JLib.New<SpriteRenderer>("PosTarget Test").Init(null, AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Knob.psd"));
            r.transform.localPosition = new Vector3(0, -i * 1);
            return r;
        });

        test_renderers[0].Add<PosTarget>().Init(new Vector3(1, 0, 0), 120, axes: new Vector3(1, 0, 0), eased: EaseType.None);
        test_renderers[1].Add<PosTarget>().Init(new Vector3(1, -1, 0), 120, axes: new Vector3(1, 0, 0), eased: EaseType.Out);
        test_renderers[2].Add<PosTarget>().Init(new Vector3(1, -2, 0), 120, axes: new Vector3(1, 0, 0), eased: EaseType.In);
        test_renderers[3].Add<PosTarget>().Init(new Vector3(1, -3, 0), 120, axes: new Vector3(1, 0, 0), eased: EaseType.Both);
    }
}
