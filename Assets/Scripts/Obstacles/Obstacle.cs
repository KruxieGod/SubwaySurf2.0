using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    [SerializeField] private ObstacleType _type;
    [SerializeField] private Collider _collider;
    private AnimatorManager _animatorManager;
    [SerializeField] private Transform _toCollide;
    private void Start()
    {
        _animatorManager = GetComponentInChildren<AnimatorManager>();
        DataColliders.OnObstacleActions.Add(_collider,Death);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (DataColliders.OnObstacleActions.TryGetValue(other,out var action)) // Получаем действие при столкновении
            action?.Invoke();
    }

    private Vector3 Death()
    {
        _collider.enabled = false;
        _animatorManager.PlayDeath();
        return _toCollide.position;
    }

    private void OnDestroy() => DataColliders.OnObstacleActions.Remove(_collider);
}