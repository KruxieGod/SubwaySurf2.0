
public class StateMachine
{
    private State _currentState;
    private readonly JumpState _jumpStateState;
    private readonly SlideState _slideStateState;
    public readonly RunningState RunningStateState;

    public StateMachine(AnimatorManager animatorManager)
    {
        RunningStateState = new RunningState(animatorManager);
        _slideStateState = new SlideState(animatorManager);
        _jumpStateState = new JumpState(animatorManager);
        _currentState = RunningStateState;
    }

    public void UpdateStateMachine()
    => _currentState = _currentState.OnState();

    public void ChangeToSlideState()
    {
        if (_currentState.CanBeSwitch)
            _currentState = _slideStateState;
    }

    public void ChangeToJumpState()
    {
        if (_currentState.CanBeSwitch)
            _currentState = _jumpStateState;
    }
}