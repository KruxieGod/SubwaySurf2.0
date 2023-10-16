using System;
using System.Collections.Generic;
using UnityEngine;

public static class DataColliders
{
    public static Dictionary<Collider, Func<Vector3>> OnObjectsForObstacles { get; private set; } = new();
    public static Dictionary<Collider, Action<ObstacleType>> OnObstacleActions { get; private set; } = new();
}