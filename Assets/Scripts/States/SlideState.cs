
using System;

public class SlideState : AnimationState
{
    public SlideState(AnimatorManager animatorManager, StateMachine stateMachine) : base(animatorManager, stateMachine,
        () =>
        {
            animatorManager.PlaySlide();// анимация скольжения
            return true;
        })
    {
    }

    protected override ObstacleType _onDestroyObstacle => ObstacleType.Fence;
}