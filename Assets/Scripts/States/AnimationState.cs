
using System;

public abstract class AnimationState : State
{
    private Func<bool> _onAnimation;
    protected abstract ObstacleType _onDestroyObstacle { get; }
    private State _currentState;
    public override State StartState() // стартуем состояние
    {
        CanBeSwitch = false; // нельзя изменить состояние
        _currentState = this;
        if (!_onAnimation.Invoke()) // проверяем на анимацию, можно оли ее воспроизвести
        {
            CanBeSwitch = true;
            return _stateMachine.RunningStateState;
        }
        return _currentState;
    }

    public override bool OnObstacle(ObstacleType type) // на тип столкновения
    {
        if (_onDestroyObstacle == type)
            return false;
        _currentState = _stateMachine.DeathState.StartState(); // если не совпадают с типом столкновения , то умер
        return true;
    }

    public override State OnState()
    => CanBeSwitch ? _stateMachine.RunningStateState.StartState() : _currentState; // обновляем каждый кадр

    public AnimationState(AnimatorManager animatorManager, StateMachine stateMachine,Func<bool> onAnimation) : base(animatorManager, stateMachine)
    {
        _onAnimation = onAnimation;
    }
}