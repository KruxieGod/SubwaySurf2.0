
public class SlideState : State
{
    
    public override State OnState()
    {
        throw new System.NotImplementedException();
    }
    
    public override bool CanBeSwitch { get; protected set; }

    public SlideState(AnimatorManager animatorManager, StateMachine stateMachine) : base(animatorManager, stateMachine)
    {
    }
}