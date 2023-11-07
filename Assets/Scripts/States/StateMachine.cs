
public class StateMachine 
{
    private State _currentState;
    private readonly JumpState _jumpStateState;
    private readonly SlideState _slideState;
    private readonly ThrowState _throwStateState;
    public readonly RunningState RunningStateState;
    public readonly DeathState DeathState;
    
    public StateMachine(AnimatorManager animatorManager,SnowballCollector snowballCollector,EndGameUI endGameUI) // в контрукторе мы принмаем аниматора менеджера и коллектор снежков
    {
        DeathState = new DeathState(animatorManager,this,endGameUI); // состояние смерти
        RunningStateState = new RunningState(animatorManager,this); // состояние бега
        _slideState = new SlideState(animatorManager,this); // состояние скольжения
        _jumpStateState = new JumpState(animatorManager,this);// состояние прыжка
        _throwStateState = new ThrowState(animatorManager, this,snowballCollector); // состояние кидания снежка
        _currentState = RunningStateState;
    }

    public bool OnObstacle(ObstacleType type) => _currentState.OnObstacle(type);

    public bool CanBeSwitch
    {
        set => _currentState.CanBeSwitch = true;
    }

    public void UpdateStateMachine()
    => _currentState = _currentState.OnState(); // обноваляем состояния

    public void ChangeToSlideState() // изменяем на скольжение
    {
        if (_currentState.CanBeSwitch)
            _currentState = _slideState.StartState(); // ставим состояние скольжения
    }

    public void ChangeToJumpState() // прыжок
    {
        if (_currentState.CanBeSwitch)
            _currentState = _jumpStateState.StartState();
    }

    public void ChangeToThrowState() // кидание снежка
    {
        if (_currentState.CanBeSwitch)
            _currentState = _throwStateState.StartState();
    }
}