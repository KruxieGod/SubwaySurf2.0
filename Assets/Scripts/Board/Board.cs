
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{
    [field: SerializeField] public Transform[] Roads { get; private set; }
    public Vector3 Scale => Roads[0].localScale;
    public Vector3 Position => transform.position;
    [SerializeField] private Obstacle[] _obstacles;
    private const float _offsetBetweenObstacles = 1f;
    private const float _offsetPlane = 10f;
    private List<Obstacle> _spawnedObstacles = new();
    public void Initialize()
    {
        var positionZ = transform.position.z + Roads[0].localScale.z*_offsetPlane/2f - _offsetPlane*_offsetBetweenObstacles/2;
        var positionX = Roads[0].position.x;
        for (int i = 0; i < Roads[0].localScale.z; i++)
        {
            var countObstacles = 1;
            for (int j = 0; j < countObstacles; j++)
            {
                var randomIndex = Random.Range(0, _obstacles.Length);
                var randomPlaceIndex = Random.Range(0, Roads.Length);
                var obstacle = _obstacles[randomIndex];
                _spawnedObstacles.Add(Instantiate(obstacle,
                    new Vector3(
                        positionX - randomPlaceIndex*_offsetPlane,
                    Roads[0].position.y,
                    positionZ),
                    Quaternion.identity));
            }
            positionZ -= _offsetBetweenObstacles*_offsetPlane;
        }
    }

    private void OnDestroy()
    {
        foreach (var obstacle in _spawnedObstacles)
            Destroy(obstacle.gameObject);
        _spawnedObstacles = null;
    }
}