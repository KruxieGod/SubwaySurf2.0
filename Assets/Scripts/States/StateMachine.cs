
public class StateMachine
{
    private State _currentState;
    private readonly JumpState _jumpStateState;
    private readonly SlideState _slideStateState;
    private readonly ThrowState _throwStateState;
    public readonly RunningState RunningStateState;
    public readonly DeathState DeathStateState;
    
    public StateMachine(AnimatorManager animatorManager)
    {
        DeathStateState = new DeathState(animatorManager,this);
        RunningStateState = new RunningState(animatorManager,this);
        _slideStateState = new SlideState(animatorManager,this);
        _jumpStateState = new JumpState(animatorManager,this);
        _throwStateState = new ThrowState(animatorManager, this);
        _currentState = RunningStateState;
    }

    public bool OnObstacle(ObstacleType type) => _currentState.OnObstacle(type);

    public bool SetStart
    {
        set => _currentState.IsStartedState = value;
    }

    public void UpdateStateMachine()
    => _currentState = _currentState.OnState();

    public void ChangeToSlideState()
    {
        if (_currentState.CanBeSwitch)
            _currentState = _slideStateState.StartState();
    }

    public void ChangeToJumpState()
    {
        if (_currentState.CanBeSwitch)
            _currentState = _jumpStateState.StartState();
    }

    public void ChangeToThrowState()
    {
        if (_currentState.CanBeSwitch)
            _currentState = _throwStateState.StartState();
    }
}