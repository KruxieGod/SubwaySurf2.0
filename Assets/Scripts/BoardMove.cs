using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class BoardMove : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform[] roads;
    private Queue<Transform> _queue = new ();
    private const float _offset = 10;
    private void Update()
    {
        if (_player.position.z < roads.First().position.z)
        {
            for (int i = 0; i < roads.Length; i++)
            {
                var road = roads[i];
                _queue.Enqueue(road);
                var positionX = road.position.x;
                var positionZ = road.position.z - road.localScale.z * _offset;
                roads[i] = Instantiate(road, new Vector3(positionX, 0, positionZ), Quaternion.identity);
                while (_queue.Count > 6)
                    Destroy( _queue.Dequeue().gameObject);
            }
        }
    }
}
