using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorManager : MonoBehaviour
{
    private Animator _animator;
    private string _deathState = "Death"; // название анимации смерти
    private void Awake()
    {
        _animator = GetComponent<Animator>(); // получаем аниматор
    }

    public void PlayDeath()
    {
        _animator.CrossFade(_deathState,0.2f); // смерть
    }
}
