using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BoardMove : MonoBehaviour
{
    [SerializeField] private Transform _player; // игрок
    [SerializeField] private Board[] _prefabs; // дорожки
    private Queue<Board> _queue = new ();
    private Board _last;
    private const float _offset = 10;
    private int _indexPlayer = 0;
    private void Start()
    {
        _last = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], transform.position, Quaternion.identity); // Спавним первую дорожку
        _last.transform.position = _player.transform.position; // Ставим позицию где игрок находится
        _last.Initialize(); // Инициализуем (он спавним препятствия)
        _queue.Enqueue(_last); // добавляем в очередь
    }

    public bool GetFromPositionToNext(Direction direction,out Vector3 position) // out - назначение позиции
    {
        if (direction == Direction.Left && _indexPlayer - 1 >= 0)  // налево по тропинкам 
            _indexPlayer--; 
        else if (direction == Direction.Right && _indexPlayer + 1 < _last.Roads.Length) // направо по тропинкам 
            _indexPlayer++;
        
        position = _last.Roads[_indexPlayer].position;
        return direction != Direction.None;
    }

    private void Update()
    {
        if (_player.position.z < _last.transform.position.z) // проверяем , если он дальше середины
        {
            var board = _prefabs[Random.Range(0, _prefabs.Length)]; // берем дорожку
            var positionX = _last.Position.x; 
            var positionY = _last.Position.y; // позиции дорожек
            var positionZ = _last.Position.z - _last.Scale.z * _offset; // позиция по z следующей дороги
            _last = Instantiate(board , new Vector3(positionX, positionY, positionZ), Quaternion.identity); // спавним по позиции
            _last.Initialize(); // спавним препятствия
            _queue.Enqueue(_last); // добавляем последную в очередь
            while (_queue.Count > 2) // и если у нас больше 2 , то мы удаляем самую первую
                Destroy( _queue.Dequeue().gameObject);
        }
    }
}
