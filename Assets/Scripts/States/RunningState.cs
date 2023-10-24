using System;

public class RunningState : State // состояние бега
{
    private State _currentState;
    public RunningState(AnimatorManager animatorManager, StateMachine stateMachine) : base(animatorManager, stateMachine)
    {
        _currentState = this;
        CanBeSwitch = true;
    }

    public override State StartState()
    {
        _animatorManager.PlayRunning(); // начинаем бегать
        return this;
    }

    public override bool OnObstacle(ObstacleType type)
    {
        _currentState = _stateMachine.DeathState.StartState(); // состояние смерти и воспроизведение анимации смерти
        return true;
    }

    public override State OnState()
        => _currentState;
}