using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{
    [field: SerializeField] public Transform[] Roads { get; private set; } // тропинки
    public Vector3 Scale => Roads[0].localScale; // размер тропинки
    public Vector3 Position => transform.position; // позиция дороги
    [SerializeField] private Obstacle[] _obstacles; // препятствия
    private const float _offsetBetweenObstacles = 1f; 
    private const float _offsetPlane = 10f;
    private List<Obstacle> _spawnedObstacles = new();// заспавненные препятствия
    public void Initialize()
    {
        var positionZ = transform.position.z + Roads[0].localScale.z*_offsetPlane/2f - _offsetPlane*_offsetBetweenObstacles/2; 
        // здесь мы вычисляем позицию для первого блока препятствий
        // текущая позиция дороги + размер тропинки * на половину оффесета - пол метра 
        var positionX = Roads[0].position.x; // позиция по x влево вправо
        for (int i = 0; i < Roads[0].localScale.z; i++) // вычисление препятствий
        {
            var countObstacles = 1;
            for (int j = 0; j < countObstacles; j++)
            {
                var randomIndex = Random.Range(0, _obstacles.Length); // индекс рандомного препятствия
                var randomPlaceIndex = Random.Range(0, Roads.Length); // местоположение его на любой из тропинок рандомно
                var obstacle = _obstacles[randomIndex]; // берем препятствие
                _spawnedObstacles.Add(Instantiate(obstacle,
                    new Vector3(
                        positionX - randomPlaceIndex*_offsetPlane, // настройка позиции
                    Roads[0].position.y,
                    positionZ),
                    Quaternion.identity));
            }
            positionZ -= _offsetBetweenObstacles*_offsetPlane;  // какая дистанция должна быть между ними
        }
    }

    private void OnDestroy()
    {
        foreach (var obstacle in _spawnedObstacles) // уничтожаем все заспавленные препятствия
            Destroy(obstacle.gameObject);
        _spawnedObstacles = null; // обнуляем массив
    }
}