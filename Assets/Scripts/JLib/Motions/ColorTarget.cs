using UnityEngine;
using UnityEngine.Events;

public class ColorTarget : MonoBehaviour
{
    private UnityAction<Color> _setColor;
    public ColorTarget Init(Color target, float speed)
    {
        if (this.Get<SpriteRenderer>()) {
            _setColor = (Color color) => { this.Get<SpriteRenderer>().color = color; };
        } // ...else if other components

        return this;
    }
}
