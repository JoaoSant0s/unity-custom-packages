using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static float Distance(this Transform main, Transform reference)
    {
        return (reference.position - main.position).magnitude;
    }

    public static void SetPositionXY(this Transform main, Vector2 position)
    {
        main.position = new Vector3(position.x, position.y, main.position.z);
    }

    public static float GetTransformDistance(this Transform main, Transform next)
    {
        return main.Distance(next);
    }

}
