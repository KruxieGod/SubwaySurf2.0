using System;
using System.Collections.Generic;
using UnityEngine;

public static class DataColliders
{
    public static Dictionary<Collider, Func<Vector3>> OnObstacleActions { get; private set; } = new();
}