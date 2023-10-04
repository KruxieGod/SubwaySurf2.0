using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    private PlayerManager _playerManager;
    private void Start()
    {
        _playerManager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        var direction = Direction.None;
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) // Считываем клавишу D или стрелку направо
            direction = Direction.Right;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) // Считываем клавишу A или стрелку налево
            direction = Direction.Left;
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _playerManager.ThrowSnow();
        _playerManager.MoveTo(direction); // передаем направление
    }
}
