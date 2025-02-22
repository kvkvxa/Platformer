using UnityEngine;

public static class Vector2Extensions
{
    public static bool IsEnoughClose(this Vector2 start, Vector2 end, float distance)
    {
        return start.SqrDistance(end) <= distance * distance;
    }

    public static Vector2 ToVector2(this Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.y);
    }

    private static float SqrDistance(this Vector2 start, Vector2 end)
    {
        return (end - start).sqrMagnitude;
    }
}