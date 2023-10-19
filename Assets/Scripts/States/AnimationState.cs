
using System;

public abstract class AnimationState : State
{
    private Action _onAnimation;
    protected abstract ObstacleType _onDestroyObstacle { get; }
    private State _currentState;
    public override State StartState()
    {
        CanBeSwitch = false;
        _currentState = this;
        _onAnimation.Invoke();
        return _currentState;
    }

    public override bool OnObstacle(ObstacleType type)
    {
        if (_onDestroyObstacle ==type)
            return false;
        _currentState = _stateMachine.DeathStateState.StartState();
        return true;
    }

    public override State OnState()
    => CanBeSwitch ? _stateMachine.RunningStateState.StartState() : _currentState;

    public AnimationState(AnimatorManager animatorManager, StateMachine stateMachine,Action onAnimation) : base(animatorManager, stateMachine)
    {
        _onAnimation = onAnimation;
    }
}