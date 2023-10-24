using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private StateMachine _stateMachine;
    [SerializeField]private MovementHandler _movementHandler;
    private BoardMove _boardMove;
    [SerializeField]private AnimatorManager _animatorManager;
    [SerializeField] private Collider _collider;
    [SerializeField] private SnowballCollector _snowballCollector;
    private bool _isDead;
    
    private void Awake() // когда появляется объект
    {
        _stateMachine = new StateMachine(_animatorManager, _snowballCollector);
        if (!DataColliders.OnObstacleActions.ContainsKey(_collider))
            DataColliders.OnObstacleActions.Add(_collider, Death);
        else
            DataColliders.OnObstacleActions[_collider] += Death;
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

    public void CanBeSwitched()
    => _stateMachine.CanBeSwitch = true;
    public void Jump() => _stateMachine.ChangeToJumpState();
    public void ThrowSnow() => _stateMachine.ChangeToThrowState();
    public void Slide() => _stateMachine.ChangeToSlideState();

    private void Death(ObstacleType type,GameObject gameObject)
    {
        if (type == ObstacleType.Snowball)
            return;
        _stateMachine.OnObstacle(type);
    }
}
