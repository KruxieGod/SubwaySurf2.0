using UnityEngine;

public class JumpState : State
{
    private State _currentState;
    public override State StartState()
    {
        IsStartedState
        _currentState = this;
        _animatorManager.PlayJump();
        return _currentState;
    }

    public override bool OnObstacle(ObstacleType type)
    {
        if (type == ObstacleType.Barrier)
            return false;
        else
        {
            _currentState = _stateMachine.DeathStateState;
            return true;
        }
    }

    public override State OnState()
    {
        if (!IsStartedState)
        return _currentState;
    }

    public JumpState(AnimatorManager animatorManager, StateMachine stateMachine) : base(animatorManager, stateMachine)
    {
    }
}