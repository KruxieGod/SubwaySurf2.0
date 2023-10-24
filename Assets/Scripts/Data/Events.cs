
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events
{
    public static Dictionary<Collider, Action> OnAddThrow { get; private set; } = new();
}