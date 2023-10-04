using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    private AnimatorManager _animatorManager;

    private void Start()
    {
        DataColliders.OnObstacleActions.Add(_collider,Death);
        _animatorManager = GetComponentInChildren<AnimatorManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (DataColliders.OnObstacleActions.TryGetValue(other,out var action)) // Получаем действие при столкновении
            action?.Invoke();
    }

    private void Death()
    {
        _collider.enabled = false;
        _animatorManager.PlayDeath();
    }
}