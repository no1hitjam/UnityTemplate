using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorTarget : VectorTargetBase
{

    public ColorTarget Init(Color target, int? time = null, Color? colorAxes = null, EaseType? easing = null)
    {
        base.Init(null, null, target, time, colorAxes, easing);

        if (this.Get<SpriteRenderer>()) {
            _setVector = (color) => { this.Get<SpriteRenderer>().color = color; };
            _getVector = () => { return this.Get<SpriteRenderer>().color; };
        } else if (this.Get<Image>()) {
            _setVector = (color) => { this.Get<Image>().color = color; };
            _getVector = () => { return this.Get<Image>().color; };
        } else if (this.Get<Text>()) {
            _setVector = (color) => { this.Get<Text>().color = color; };
            _getVector = () => { return this.Get<Text>().color; };
        } else {
            Debug.LogError("ColorTarget: _setColor not initialized");
            Debug.Break();
        }

        return this;
    }

    public override void Update()
    {
        base.Update();
    }
}
