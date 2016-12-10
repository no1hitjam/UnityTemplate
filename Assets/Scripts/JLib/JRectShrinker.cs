using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(JRender))]
[DisallowMultipleComponent]
public class JRectShrinker : JBehaviour
{
    public float max_size;
    public JLib.Axis axis;
    private JQueuePair<float> change_size;

    void Start()
    {
        change_size = new JQueuePair<float>(
            (float f) => { transform.localScale = JLib.SetAxis(transform.localScale, axis, (float f2) => f2 * f); },
            (float f) => { transform.localScale = JLib.SetAxis(transform.localScale, axis, (float f2) => f2 / f); }, 
            1);
    }

    void Update()
    {
        var size = JLib.GetAxis(GetComponent<RectTransform>().sizeDelta, axis);
        if (size > max_size) {
            change_size.Add(max_size / size);
        } else {
            change_size.Add(1);
        }
    }
    /*
    void OnEnable()
    {

    }

    void OnDisable()
    {
        
    }
    */
}

