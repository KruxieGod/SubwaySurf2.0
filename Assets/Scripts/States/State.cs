
public abstract class State
{
    protected AnimatorManager _animatorManager;
    protected StateMachine _stateMachine;
    protected State(AnimatorManager animatorManager, StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _animatorManager = animatorManager;
    }

    public abstract State StartState();
    public abstract bool OnObstacle(ObstacleType type);
    public abstract State OnState();
    public bool CanBeSwitch { get; set; }
}