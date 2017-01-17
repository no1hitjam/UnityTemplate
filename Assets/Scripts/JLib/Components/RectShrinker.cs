using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[DisallowMultipleComponent]
public class RectShrinker : MonoBehaviour
{
    public float max_size;
    public JLib.Axis axis;
    private JQueuePair<float> _changeSize;
    private float _lastSize = 0;

    void Start()
    {
        // multiply by changed size proportion and divide by old
        _changeSize = new JQueuePair<float>(1, 
            (mult) => this.SetScale((v) => { return v.SetAxis(axis, (f) => { return mult * f; }); }),
            (mult) => this.SetScale((v) => { return v.SetAxis(axis, (f) => { return mult / f; }); }));
    }

    void Update()
    {
        // when size changes, check if bigger than max size
        // if so, scale to proportion
        var size = this.Get<RectTransform>().sizeDelta.GetAxis(axis);
        if (size > max_size && size != _lastSize) {
            _changeSize.Add(max_size / size);
            _lastSize = size;
        } else {
            _changeSize.Add(1);
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

