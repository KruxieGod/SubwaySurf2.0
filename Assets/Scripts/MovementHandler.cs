using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementHandler : MonoBehaviour
{
    [SerializeField] private float _speed; // берем с инспектора
    private float _targetPos;
    private float _previousPos;
    [SerializeField] private float _speedTimeToPos;// берем с инспектора
    public float Coefficient = 1f;
    private bool _canMove;
    private Vector3 _velocity = Vector3.zero;
    private CharacterController _controller;

    private void Awake()
        => _controller = GetComponent<CharacterController>();

    public void MoveToX(Vector3 position)
    {
        _canMove = true; // разрешаем идти
        _targetPos = position.x; // ставим позицию куда нам нужно идти
        _previousPos = transform.position.x; // позиция откуда он будет идти
    }

    public void Move()
    {
        var direction = transform.forward*(_speed*Coefficient); // направление вперед
        _controller.Move(direction * Time.deltaTime);// прибавляем к позиции направление
        _velocity.y += Physics.gravity.y * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
        var toTarget = _targetPos - transform.position.x; // направление движения вправо-влево
        if (_canMove && Mathf.Abs(toTarget) > Double.Epsilon) // дистанция , если она равна нулю Mathf.Abs(toTarget) > Double.Epsilon/Mathf.Abs(toTarget) == 0 
        {
            _previousPos = Mathf.MoveTowards(_previousPos, _targetPos,_speedTimeToPos * Time.deltaTime); // вычисляем плавно дистанцию
            var currentPosition = transform.position; // текущая позиция
            transform.position = new Vector3(_previousPos,currentPosition.y, currentPosition.z); // ставим позицию , которую мы плавно вычислили
        }
        else
            _canMove = false; // не может двигаться, если пришел

        
    }
}
