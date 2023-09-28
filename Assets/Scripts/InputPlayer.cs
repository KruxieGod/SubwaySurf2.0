using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    private PlayerManager _mover;
    private void Start()
    {
        _mover = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        var direction = Direction.None;
        if (Input.GetKeyDown(KeyCode.D))
            direction = Direction.Right;
        if (Input.GetKeyDown(KeyCode.A))
            direction = Direction.Left;
        _mover.MoveTo(direction);
    }
}
