using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField]private Animator _animator;
    private const string _deathState = "Death"; // название анимации смерти
    private const string _snowballThrowState = "Throw snowball";
    private const string _jumpState = "Jump";
    private const string _slideState = "Slide";
    private const string _runningState = "Run";

    public void PlayDeath()
    => _animator.CrossFade(_deathState,0.2f); // смерть

    public void PlaySnowballThrower()
    => _animator.CrossFade(_snowballThrowState,0.2f);

    public void PlayJump()
    => _animator.CrossFade(_jumpState,0.2f);

    public void PlaySlide()
    => _animator.CrossFade(_slideState,0.2f);
    
    public void PlayRunning()
        => _animator.CrossFade(_runningState,0.2f); // передаем плавно анимацию бега
}