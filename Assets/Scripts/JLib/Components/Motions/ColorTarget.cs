using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ColorTarget : Motion
{
    private UnityAction<Color> _setColor;
    public ColorTarget Init(Color target, float speed)
    {
        if (this.Get<SpriteRenderer>()) {
            _setColor = (Color color) => { this.Get<SpriteRenderer>().color = color; };
        } else if (this.Get<Image>()) {
            _setColor = (Color color) => { this.Get<Image>().color = color; };
        } else if (this.Get<Text>()) {
            _setColor = (Color color) => { this.Get<Text>().color = color; };
        } else {
            Debug.LogError("ColorTarget: _setColor not initialized");
            Debug.Break();
        }

        return this;
    }

    void Update()
    {
        if (ActiveFrame) {

        }
    }
}
