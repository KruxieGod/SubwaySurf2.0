
public abstract class State
{
    protected AnimatorManager _animatorManager;
    protected State(AnimatorManager animatorManager) => _animatorManager = animatorManager;
    public abstract State OnState();
    public abstract bool CanBeSwitch { get; protected set; }
}