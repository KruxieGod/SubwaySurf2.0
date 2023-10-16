public class RunningState : State
{
    public RunningState(AnimatorManager animatorManager) : base(animatorManager)
    {
        CanBeSwitch = true;
    }
    
    public override State OnState()
    {
        throw new System.NotImplementedException();
    }

    public sealed override bool CanBeSwitch { get; protected set; }
}