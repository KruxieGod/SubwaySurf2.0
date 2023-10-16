public class RunningState : State
{
   
    
    public override State OnState()
    {
        throw new System.NotImplementedException();
    }

    public sealed override bool CanBeSwitch { get; protected set; }

    public RunningState(AnimatorManager animatorManager, StateMachine stateMachine) : base(animatorManager, stateMachine)
    {
    }
}