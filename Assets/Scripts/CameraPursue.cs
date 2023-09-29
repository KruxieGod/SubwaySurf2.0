using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPursue : MonoBehaviour
{
    [SerializeField] private Transform _player; // игрок 

    private void Update()
    {
        transform.position = _player.position; // камера преследует игрока
    }
}
