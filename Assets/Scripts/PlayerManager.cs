using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private MovementHandler _movementHandler;
    private BoardMove _boardMove;
    private void Awake()
    {
        _movementHandler = GetComponent<MovementHandler>();
    }

    public void SubscribeBoard(BoardMove boardMove)
    {
        _boardMove = boardMove;
    }

    public void MoveTo(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                _movementHandler.MoveTo(_boardMove.GetFromPositionToNext(direction));
                break;
            case Direction.Right:
                _movementHandler.MoveTo(_boardMove.GetFromPositionToNext(direction));
                break;
        }

        _movementHandler.Move();
    }
}
