
public class DeathState : State
{
    public DeathState(AnimatorManager animatorManager, StateMachine stateMachine) : base(animatorManager, stateMachine)
    {
    }

    public override State StartState()
    {
        _animatorManager.PlayDeath();
        return this;
    }

    public override bool OnObstacle(ObstacleType type)
        => true;

    public override State OnState()
        => this;
}