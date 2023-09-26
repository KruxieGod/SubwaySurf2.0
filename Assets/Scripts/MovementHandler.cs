using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;

    public void Move(float direction)
    {
        var dir = new Vector3(direction, 0, 0);
        transform.position += transform.forward*_speed;
        transform.position += dir * _speed;
    }
}
