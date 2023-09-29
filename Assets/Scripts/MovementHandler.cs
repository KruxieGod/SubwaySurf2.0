using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementHandler : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _targetPos;
    private float _previousPos;
    [SerializeField] private float _speedTimeToPos;
    private Rigidbody _rb;
    private bool _canMove;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void MoveToX(Vector3 position)
    {
        _canMove = true;
        _targetPos = position.x;
        _previousPos = transform.position.x;
    }

    public void Move()
    {
        var direction = transform.forward*_speed;
        var toTarget = _targetPos - transform.position.x;
        if (_canMove && Mathf.Abs(toTarget) > Double.Epsilon)
        {
            _previousPos = Mathf.MoveTowards(_previousPos, _targetPos,_speedTimeToPos * Time.deltaTime);
            var currentPosition = transform.position;
            transform.position = new Vector3(_previousPos,currentPosition.y, currentPosition.z);
        }
        else
            _canMove = false;
        
        transform.position += direction*Time.deltaTime;
    }
}
