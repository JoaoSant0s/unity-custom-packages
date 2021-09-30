using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class UtilWrapper
{
    public static bool IsPointOverUIObject<T>()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);

        eventDataCurrentPosition.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        results = results.FindAll(r => r.gameObject.GetComponent<T>() == null);

        return results.Count > 0;
    }

    public static bool WasDistanceLessThan(Transform p, Transform next, float distance)
    {
        if (distance < 0) return true;

        return p.GetTransformDistance(next) < distance;
    }

    public static bool ContainsAPoint(Vector2 basePoint, Vector2 nextPoint, Vector2 area)
    {
        var checkLeftHorizontal = nextPoint.x >= basePoint.x - area.x / 2f;
        var checkRightHorizontal = nextPoint.x <= basePoint.x + area.x / 2f;

        var checkTopVertical = nextPoint.y <= basePoint.y + area.y / 2f;
        var checkDownVertical = nextPoint.y >= basePoint.y - area.y / 2f;

        var checkHorizontal = checkLeftHorizontal && checkRightHorizontal;
        var checkVertical = checkTopVertical && checkDownVertical;

        return checkHorizontal && checkVertical;
    }

    public static Transform GetNearestElement(Transform reference, List<Transform> list)
    {
        if (list.Count == 0) return null;

        var minDistance = float.MaxValue;
        Transform nearestElement = null;

        for (int i = 0; i < list.Count; i++)
        {
            float distance = reference.GetTransformDistance(list[i].transform);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestElement = list[i].transform;
            }
        }

        return nearestElement;
    }

    public static Transform GetNearestElement(Transform reference, List<Transform> list, Vector2 container)
    {
        if (list.Count == 0) return null;

        var minDistance = float.MaxValue;
        Transform nearestElement = null;

        for (int i = 0; i < list.Count; i++)
        {
            var element = list[i].transform;

            float distance = reference.GetTransformDistance(element);

            if (!ContainsAPoint(reference.position, element.position, container)) continue;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestElement = element;
            }
        }

        return nearestElement;
    }

    public static Vector2 GetNearestVector(Vector2 reference, Vector2[] list)
    {
        var minDistance = float.MaxValue;
        Vector2 nearestElement = reference;

        for (int i = 0; i < list.Length; i++)
        {
            float distance = Vector2.Distance(reference, list[i]);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestElement = list[i];
            }
        }

        return nearestElement;        
    }

    public static string PositiveNumberFormat(int value)
    {
        var convert = value.ToString();

        if (convert.Length == 1) convert = "0" + convert;

        return convert;
    }
}
