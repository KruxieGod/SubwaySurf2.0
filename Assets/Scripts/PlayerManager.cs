using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private StateMachine _stateMachine;
    private MovementHandler _movementHandler;
    private BoardMove _boardMove;
    private AnimatorManager _animatorManager;
    private bool _isDead;
    
    private void Awake() // когда появляется объект
    {
        _animatorManager = GetComponent<AnimatorManager>(); // получаем скрипт аниматора
        _movementHandler = GetComponent<MovementHandler>(); // получаем скрипт передвижения
        _stateMachine = new StateMachine(_animatorManager);
        DataColliders.OnObstacleActions.Add(GetComponent<Collider>(),Death);
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
        _stateMachine.UpdateStateMachine();
        _movementHandler.Move(); // бежит
    }

    public void OnCurrentStateStart(bool isStarted) => _stateMachine.SetStart = isStarted;
    public void Jump() => _stateMachine.ChangeToJumpState();
    public void ThrowSnow() => _stateMachine.ChangeToThrowState();
    public void Slide() => _stateMachine.ChangeToSlideState();

    private void Death(ObstacleType type)
        => _stateMachine.OnObstacle(type);
}
