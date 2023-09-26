using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    private IMovable _mover;
    [SerializeField] private Transform _cube;
    private void Start()
    {
        _mover = GetComponent<MovementHandler>();
    }

    private void Update()
    {
        float direction = 0;
        if (Input.GetKey(KeyCode.D))
            direction = -1;
        if (Input.GetKey(KeyCode.A))
            direction = 1;
        _mover.Move(direction);
    }
}
