
public class ThrowState : State
{
    public ThrowState(AnimatorManager animatorManager,StateMachine stateMachine) : base(animatorManager)
    {
    }

    public override State OnState()
    {
       
    }

    public override bool CanBeSwitch { get; protected set; }
}