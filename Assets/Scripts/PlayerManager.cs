using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private MovementHandler _movementHandler;
    private BoardMove _boardMove;
    private AnimatorManager _animatorManager;
    private bool _isDead;
    
    private void Awake() // когда появляется объект
    {
        _animatorManager = GetComponent<AnimatorManager>(); // получаем скрипт аниматора
        _movementHandler = GetComponent<MovementHandler>(); // получаем скрипт передвижения
    }

    public void SubscribeBoard(BoardMove boardMove)
    {
        _boardMove = boardMove;// получили скрипт передвижения дорог
    }
    
    public void MoveTo(Direction direction)
    {
        if (_isDead)
            return;
        switch (direction)
        {
            case Direction.Left:
            case Direction.Right:
                if (_boardMove.GetFromPositionToNext(direction,out var pos)) // получаем позицию следующей дорожки
                    _movementHandler.MoveToX(pos); // передаем позицию куда нам надо идти
                break;
        }

        _movementHandler.Move(); // бежит
    }

    public void Death()
    {
        _isDead = true;
        _animatorManager.PlayDeath();
    }
}
