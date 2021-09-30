using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 RandomVector2(float x, float y)
    {
        return new Vector2(Random.Range(x, y), Random.Range(x, y));
    }

    public static Vector2 RandomVector2(float xMin, float xMax, float yMin, float yMax)
    {
        return new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
    }

    public static Vector2 NegateVector(this Vector2 value)
    {
        value.x = -value.x;
        value.y = -value.y;
        return value;
    }
}
