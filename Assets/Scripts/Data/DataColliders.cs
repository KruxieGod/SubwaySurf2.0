using System;
using System.Collections.Generic;
using UnityEngine;

public static class DataColliders
{
    public static Dictionary<Collider, Action> OnObstacleActions { get; private set; } = new();
}