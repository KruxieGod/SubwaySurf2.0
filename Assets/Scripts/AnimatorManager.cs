using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorManager : MonoBehaviour
{
    private Animator _animator;
    private const string _deathState = "Death"; // название анимации смерти
    private const string _snowballThrowState = "Throw snowball";
    private const string _jumpState = "Jump";
    private void Awake()
    {
        _animator = GetComponent<Animator>(); // получаем аниматор
    }

    public void PlayDeath()
    {
        _animator.CrossFade(_deathState,0.2f); // смерть
    }

    public void PlaySnowballThrower()
    {
        _animator.CrossFade(_snowballThrowState,0.2f);
    }

    public void PlayJump()
    {
        _animator.CrossFade(_jumpState,0.2f);
    }
}
