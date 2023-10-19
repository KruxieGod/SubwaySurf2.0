
using System;

public class SlideState : AnimationState
{
    public SlideState(AnimatorManager animatorManager, StateMachine stateMachine) : base(animatorManager, stateMachine, animatorManager.PlaySlide)
    {
    }

    protected override ObstacleType _onDestroyObstacle => ObstacleType.Fence;
}