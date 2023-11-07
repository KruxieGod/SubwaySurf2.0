
public class DeathState : State
{
    private readonly EndGameUI _endGameUI;

    public DeathState(AnimatorManager animatorManager, StateMachine stateMachine,EndGameUI endGameUI) : base(animatorManager, stateMachine)
    {
        _endGameUI = endGameUI;
    }

    public override State StartState()
    {
        _endGameUI.Activate();
        _animatorManager.PlayDeath();
        return this;
    }

    public override bool OnObstacle(ObstacleType type)
        => true;

    public override State OnState()
        => this;
}