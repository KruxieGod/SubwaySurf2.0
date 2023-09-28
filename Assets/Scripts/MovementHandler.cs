using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementHandler : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _targetPos;
    private Rigidbody _rb;
    private bool _canMove;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void MoveTo(Vector3 position)
    {
        _canMove = true;
        _targetPos = position;
    }

    public void Move()
    {
        var direction = transform.forward*_speed;
        var dir = (_targetPos - transform.position).normalized.x;
        if (_canMove && Mathf.Abs(dir) > Double.Epsilon)
            transform.position = new Vector3(_targetPos.x,transform.position.y,transform.position.z);
            //direction += new Vector3(dir, 0, 0)*_speed*2f;
        else
            _canMove = false;
        _rb.velocity = direction*Time.deltaTime;
    }
}
