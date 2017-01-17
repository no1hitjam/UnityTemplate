using UnityEngine;
using UnityEngine.UI;

public static class JUIExtensions
{
    public enum TextFitMode { StretchX, ShrinkX, StretchY, ShrinkY }

    public static Vector2 GetPivot(this MaskableGraphic graphic)
    {
        return graphic.Get<RectTransform>().pivot;
    }

    public static void SetPivot(this MaskableGraphic graphic, Vector2 pivot)
    {
        graphic.Get<RectTransform>().pivot = pivot;
    }

    public static Vector2 GetSize(this MaskableGraphic graphic)
    {
        return graphic.Get<RectTransform>().sizeDelta;
    }

    public static void SetSize(this MaskableGraphic graphic, Vector2 size)
    {
        graphic.Get<RectTransform>().sizeDelta = size;
    }

    public static Text Init(
        this Text text,
        Transform parent,
        string content = "",
        float width = 400,
        float height = 200,
        int font_size = 100,
        string font = "Arial",
        Color? color = null,
        TextAnchor alignment = TextAnchor.MiddleCenter,
        TextFitMode? fit = null)
    {
        text = new GameObject().AddComponent<Text>();
        text.transform.SetParent(parent, false);

        text.text = content;
        text.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        text.fontSize = font_size;
        text.font = JGet.Font(font);
        text.alignment = alignment;

        if (color.HasValue) {
            text.color = color.Value;
        } else {
            text.color = Color.black;
        }

        if (fit.HasValue) {
            var fitter = text.gameObject.AddComponent<ContentSizeFitter>();
            if (fit.Value == TextFitMode.ShrinkX || fit.Value == TextFitMode.StretchX) {
                fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
                if (fit.Value == TextFitMode.ShrinkX) {
                    var shrinker = text.gameObject.AddComponent<JRectShrinker>();
                    shrinker.max_size = width;
                    shrinker.axis = JLib.Axis.X;
                }
            } else if (fit.Value == TextFitMode.ShrinkY || fit.Value == TextFitMode.StretchY) {
                fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
                if (fit.Value == TextFitMode.ShrinkY) {
                    var shrinker = text.gameObject.AddComponent<JRectShrinker>();
                    shrinker.max_size = height;
                    shrinker.axis = JLib.Axis.Y;
                }
            }
        } else {
            UnityEngine.Object.Destroy(text.Get<ContentSizeFitter>());
            UnityEngine.Object.Destroy(text.Get<JRectShrinker>());
        }

        return text;
    }


    public static Image Init(
        this Image image, 
        Transform parent, 
        Sprite sprite = null, 
        Color? color = null,
        Vector2? size = null, 
        Vector2 pivot = default(Vector2))
    {
        image.transform.SetParent(parent, false);
        image.sprite = sprite;
        if (color.HasValue) {
            image.color = color.Value;
        }
        if (size.HasValue) {
            image.SetSize(size.Value);
        }
        image.SetPivot(pivot);

        return image;
    }

    /*public static Font Init(string name)
    {

    }*/

}

