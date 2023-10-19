
using System;

public class ThrowState : AnimationState
{
    public ThrowState(AnimatorManager animatorManager, StateMachine stateMachine) : base(animatorManager, stateMachine, animatorManager.PlaySnowballThrower)
    {
    }

    protected override ObstacleType _onDestroyObstacle => ObstacleType.Barrier | ObstacleType.Fence | ObstacleType.Wall;
}