
using System;

public class ThrowState : AnimationState
{
    public ThrowState(AnimatorManager animatorManager, StateMachine stateMachine, SnowballCollector snowballCollector)
        : base(animatorManager, stateMachine, () =>
    {
        if (!snowballCollector.CanThrow()) 
            return false;
        animatorManager.PlaySnowballThrower();// анимация бросания снежка
        return true;

    })
    {
        
    }

    protected override ObstacleType _onDestroyObstacle => ObstacleType.Barrier | ObstacleType.Fence | ObstacleType.Wall;
}