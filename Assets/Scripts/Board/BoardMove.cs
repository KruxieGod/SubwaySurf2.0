using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BoardMove : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Board[] _prefabs;
    private Queue<Board> _queue = new ();
    private Board _last;
    private const float _offset = 10;
    private int _indexPlayer = 0;
    private void Start()
    {
        _last = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], transform.position, Quaternion.identity);
        _last.transform.position = _player.transform.position;
        _queue.Enqueue(_last);
    }

    public Vector3 GetFromPositionToNext(Direction direction)
    {
        if (direction == Direction.Left && _indexPlayer - 1 > 0)
            return _last.Roads[--_indexPlayer].position;
        if (direction == Direction.Right && _indexPlayer + 1 < _last.Roads.Length)
            return _last.Roads[++_indexPlayer].position;
        return Vector3.zero;
    }

    private void Update()
    {
        if (_player.position.z < _last.transform.position.z)
        {
            var board = _prefabs[Random.Range(0, _prefabs.Length)];
            var positionX = _last.Position.x;
            var positionY = _last.Position.y;
            var positionZ = _last.Position.z - _last.Scale.z * _offset;
            _last = Instantiate(board , new Vector3(positionX, positionY, positionZ), Quaternion.identity);
            _queue.Enqueue(_last);
            while (_queue.Count > 2)
                Destroy( _queue.Dequeue().gameObject);
        }
    }
}
