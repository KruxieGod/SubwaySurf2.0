
public class ThrowState : State
{
    public override State OnState()
    {
        return this;
    }

    public override bool CanBeSwitch { get; protected set; }

    public ThrowState(AnimatorManager animatorManager, StateMachine stateMachine) : base(animatorManager, stateMachine)
    {
    }
}