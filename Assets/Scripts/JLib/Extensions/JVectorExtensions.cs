using System;
using UnityEngine;

public static class JVectorExtensions
{
    public static Vector3 JScale(this Vector3 v, Vector3 scale)
    {
        v.Scale(scale);
        return v;
    }

    public static Vector2 JScale(this Vector2 v, Vector2 scale)
    {
        v.Scale(scale);
        return v;
    }

    public static float GetAxis(this Vector3 vector, JLib.Axis axis)
    {
        if (axis == JLib.Axis.X) {
            return vector.x;
        } else if (axis == JLib.Axis.Y) {
            return vector.y;
        }
        return vector.z;
    }

    public static Vector3 SetAxis(this Vector3 vector, JLib.Axis axis, float value)
    {
        return vector.SetAxis(axis, (f) => { return value; });
    }

    public static Vector3 SetAxis(this Vector3 vector, JLib.Axis axis, Func<float, float> value)
    {
        if (axis == JLib.Axis.X) {
            vector.x = value(vector.x);
        } else if (axis == JLib.Axis.Y) {
            vector.y = value(vector.y);
        } else {
            vector.z = value(vector.z);
        }
        return vector;
    }

    public static float GetAxis(this Vector2 vector, JLib.Axis axis)
    {
        if (axis == JLib.Axis.X)
            return vector.x;
        if (axis == JLib.Axis.Y)
            return vector.y;
        return 0;
    }

    public static Vector2 SetAxis(this Vector2 vector, JLib.Axis axis, float value)
    {
        return vector.SetAxis(axis, (f) => { return value; });
    }

    public static Vector2 SetAxis(this Vector2 vector, JLib.Axis axis, Func<float, float> value)
    {
        if (axis == JLib.Axis.X) {
            vector.x = value(vector.x);
        } else if (axis == JLib.Axis.Y) {
            vector.y = value(vector.y);
        }
        return vector;
    }
}