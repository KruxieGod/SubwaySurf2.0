
public class DeathState : State
{
    public DeathState(AnimatorManager animatorManager, StateMachine stateMachine) : base(animatorManager, stateMachine)
    {
        CanBeSwitch = false;
    }

    public override bool OnObstacle(ObstacleType type)
        => true;

    public override State OnState()
    {
        _animatorManager.PlayDeath();
        return this;
    }

    public override bool CanBeSwitch { get; protected set; }
}