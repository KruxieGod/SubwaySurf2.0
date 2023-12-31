using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    [SerializeField] private ObstacleType _type;
    [SerializeField] private Collider _collider;
    private AnimatorManager _animatorManager;
    [SerializeField] private Transform _toCollide;
    [SerializeField] private bool _isEnvironment;
    private void Start()
    {
        _animatorManager = GetComponentInChildren<AnimatorManager>();
        DataColliders.OnObjectsForObstacles.Add(_collider,Death);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (DataColliders.OnObstacleActions.TryGetValue(other, out var action)) // Получаем действие при столкновении
            action?.Invoke(_type,gameObject);
    }

    private Vector3 Death()
    {
        if (!_isEnvironment)
        {
            _collider.enabled = false;
            _animatorManager.PlayDeath();   
        }
        return _toCollide.position;
    }

    private void OnDestroy() => DataColliders.OnObjectsForObstacles.Remove(_collider);
}