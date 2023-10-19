using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    private PlayerManager _playerManager;
    private bool _canInput = true;
    private void Start()
    {
        _playerManager = GetComponent<PlayerManager>();
    }

    public void DisableInput() => _canInput = false;

    private void Update()
    {
        if (!_canInput)
            return;
        var direction = Direction.None;
        if (Input.GetKeyDown(KeyCode.Space))
            _playerManager.Jump();
        if (Input.GetKeyDown(KeyCode.S))
            _playerManager.Slide();
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) // Считываем клавишу D или стрелку направо
            direction = Direction.Right;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) // Считываем клавишу A или стрелку налево
            direction = Direction.Left;
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _playerManager.ThrowSnow();
        _playerManager.MoveTo(direction); // передаем направление
    }
}
