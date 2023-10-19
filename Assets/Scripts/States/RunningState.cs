using System;

public class RunningState : State
{
    private State _currentState;
    public RunningState(AnimatorManager animatorManager, StateMachine stateMachine) : base(animatorManager, stateMachine)
    {
        _currentState = this;
        CanBeSwitch = true;
    }

    public override State StartState()
    {
        _animatorManager.PlayRunning();
        return this;
    }

    public override bool OnObstacle(ObstacleType type)
    {
        _currentState = _stateMachine.DeathStateState.StartState();
        return true;
    }

    public override State OnState()
        => _currentState;
}