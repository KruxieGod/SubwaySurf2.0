using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerManager _player;
    [SerializeField] private BoardMove _boardMove;

    private void Start()
    {
        _player.SubscribeBoard(_boardMove);
    }
}
