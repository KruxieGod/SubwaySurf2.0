using UnityEngine;

public class JumpState : State
{
    public JumpState(AnimatorManager animatorManager) : base(animatorManager)
    {
        
    }
    
    public override State OnState()
    {
        throw new System.NotImplementedException();
    }

    public override bool CanBeSwitch { get; protected set; }
}