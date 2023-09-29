using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementHandler : MonoBehaviour
{
    [SerializeField] private float _speed; // берем с инспектора
    private float _targetPos;
    private float _previousPos;
    [SerializeField] private float _speedTimeToPos;// берем с инспектора
    private bool _canMove;

    public void MoveToX(Vector3 position)
    {
        _canMove = true; // разрешаем идти
        _targetPos = position.x; // ставим позицию куда нам нужно идти
        _previousPos = transform.position.x; // позиция откуда он будет идти
    }

    public void Move()
    {
        var direction = transform.forward*_speed; // направление вперед
        var toTarget = _targetPos - transform.position.x; // направление движения вправо-влево
        if (_canMove && Mathf.Abs(toTarget) > Double.Epsilon) // дистанция , если она равна нулю Mathf.Abs(toTarget) > Double.Epsilon/Mathf.Abs(toTarget) == 0 
        {
            _previousPos = Mathf.MoveTowards(_previousPos, _targetPos,_speedTimeToPos * Time.deltaTime); // вычисляем плавно дистанцию
            var currentPosition = transform.position; // текущая позиция
            transform.position = new Vector3(_previousPos,currentPosition.y, currentPosition.z); // ставим позицию , которую мы плавно вычислили
        }
        else
            _canMove = false; // не может двигаться, если пришел
        
        transform.position += direction*Time.deltaTime; // прибавляем к позиции направление
    }
}
