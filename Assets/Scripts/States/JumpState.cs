using System;
using UnityEngine;
using DG.Tweening;
public class JumpState : AnimationState
{
    public JumpState(AnimatorManager animatorManager, StateMachine stateMachine) : base(animatorManager, stateMachine,
        animatorManager.PlayJump)
    {
    }

    protected override ObstacleType _onDestroyObstacle =>  ObstacleType.Barrier ;
}